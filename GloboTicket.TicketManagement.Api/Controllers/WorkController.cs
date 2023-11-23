using GloboTicket.TicketManagement.Application.Features.CategoryTypes.Queries.GetCategoryTypeList;
using GloboTicket.TicketManagement.Application.Features.Works.Queries.GetWorkList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
    }
}
