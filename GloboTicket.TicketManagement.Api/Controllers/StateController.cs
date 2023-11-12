using GloboTicket.TicketManagement.Application.Features.States.Queries.GetStateQueryList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize]
        [HttpGet("all", Name = "GetAllStates")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<StateListVm>>> GetAllStates()
        {
            var dtos = await _mediator.Send(new GetStateListQuery());
            return Ok(dtos);
        }
    }
}
