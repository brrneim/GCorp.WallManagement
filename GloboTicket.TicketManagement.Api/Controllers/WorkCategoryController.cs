using GloboTicket.TicketManagement.Application.Features.WorkCategory.Commands;
using GloboTicket.TicketManagement.Application.Features.WorkCategory.Queries.GetWorkCategoryList;
using GloboTicket.TicketManagement.Application.Features.Works.Commands;
using GloboTicket.TicketManagement.Application.Features.Works.Queries.GetWorkList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize]
        [HttpGet(Name = "GetAllWorkCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<WorkCategoryListVm>>> GetAllWorkCategories()
        {
            var dtos = await _mediator.Send(new GetWorkCategoryListQuery());
            return Ok(dtos);
        }

        [HttpPost(Name = "AddWorkCategory")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateWorkCategoryCommand createWorkCategoryCommand)
        {
            var response = await _mediator.Send(createWorkCategoryCommand);
            return Ok(response);
        }
    }
}
