using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using GloboTicket.TicketManagement.Application.Features.CategoryTypes.Queries.GetCategoryTypeList;
using GloboTicket.TicketManagement.Application.Features.Customers.Commands.CreateCustomer;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using GloboTicket.TicketManagement.Application.Features.Works.Commands;
using GloboTicket.TicketManagement.Application.Features.Works.Queries.GetWorkDetail;
using GloboTicket.TicketManagement.Application.Features.Works.Queries.GetWorkList;
using GloboTicket.TicketManagement.Application.Features.Works.Queries.GetWorkListByFilter;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize]
        [HttpGet(Name = "GetAllWorks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<WorkListVm>>> GetAllWorks()
        {
            var dtos = await _mediator.Send(new GetWorkListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetWorkById")]
        public async Task<ActionResult<EventDetailVm>> GetWorkById(Guid id)
        {
            var getWorkDetailQuery = new GetWorkDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getWorkDetailQuery));
        }

        [HttpPost(Name = "AddWork")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateWorkCommand createWorkCommand)
        {
            var response = await _mediator.Send(createWorkCommand);
            return Ok(response);
        }

        //[HttpGet("allwithevents", Name = "GetAllWorksByFilter")]
        //[ProducesDefaultResponseType]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<List<CategoryEventListVm>>> GetAllWorksByFilter(bool includeHistory)
        //{
        //    GetCategoriesListWithEventsQuery getCategoriesListWithEventsQuery = new GetCategoriesListWithEventsQuery() { IncludeHistory = includeHistory };

        //    var dtos = await _mediator.Send(getCategoriesListWithEventsQuery);
        //    return Ok(dtos);
        //}

        [HttpGet("allworksbyfilter", Name = "GetAllWorksByFilter")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PagedWorkListByFilterVm>> GetAllWorksByFilter(DateTime fromDate, DateTime toDate, Guid selectedCategoryId, Guid selectedCityId, Guid selectedCountyId, int page, int size)
        {
            WorkFilterDto workFilterDto = new WorkFilterDto()
            {
                  CategoryId = selectedCategoryId,
                  CityId  = selectedCityId,
                  CountyId = selectedCountyId,
                  FromTime = fromDate,
                  ToTime = toDate,
                  Page = page,
                  Size = size

            };

            var getWorkListByFilterQuery = new GetWorkListByFilterQuery() { WorkFilterDto = workFilterDto };
           
            var dtos = await _mediator.Send(getWorkListByFilterQuery);
            return Ok(dtos);
        }
    }
}
