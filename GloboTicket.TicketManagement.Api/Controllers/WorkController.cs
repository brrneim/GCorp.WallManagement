using GloboTicket.TicketManagement.Application.Features.CategoryTypes.Queries.GetCategoryTypeList;
using GloboTicket.TicketManagement.Application.Features.Customers.Commands.CreateCustomer;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using GloboTicket.TicketManagement.Application.Features.Works.Commands;
using GloboTicket.TicketManagement.Application.Features.Works.Queries.GetWorkDetail;
using GloboTicket.TicketManagement.Application.Features.Works.Queries.GetWorkList;
using MediatR;
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
        public async Task<ActionResult<CreateWorkCommandResponse>> Create([FromBody] CreateWorkCommand createWorkCommand)
        {
            var response = await _mediator.Send(createWorkCommand);
            return Ok(response);
        }
    }
}
