using GloboTicket.TicketManagement.Application.Features.CustomerMessages.Commands;
using GloboTicket.TicketManagement.Application.Features.CustomerMessages.Queries;
using GloboTicket.TicketManagement.Application.Features.CustomerMessages.Queries.GetCustomerMessageDetail;
using GloboTicket.TicketManagement.Application.Features.CustomerMessages.Queries.GetCustomerMessageList;
using GloboTicket.TicketManagement.Application.Features.Localizations.Queries.GetLocalizationQueryList;
using GloboTicket.TicketManagement.Application.Features.Works.Commands;
using GloboTicket.TicketManagement.Application.Features.Works.Queries.GetWorkDetail;
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
    public class CustomerMessageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerMessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "AddCustomerMessage")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCustomerMessageCommand createCustomerMessageCommand)
        {
            var response = await _mediator.Send(createCustomerMessageCommand);
            return Ok(response);
        }

        //[Authorize]
        [HttpGet("CustomerMessages", Name = "GetCustomerMessagesbyWorkId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CustomerMessageListVm>>> GetCustomerMessages(Guid workId)
        {
            var dtos = await _mediator.Send(new GetCustomerMessageListQuery());
            dtos = dtos.Where(a => a.WorkId == workId).ToList();
            return Ok(dtos);
        }

        //[Authorize]
        [HttpGet("AllCustomerMessages", Name = "GetCustomerMessages")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CustomerMessageListVm>>> GetAllCustomerMessages()
        {
            var dtos = await _mediator.Send(new GetCustomerMessageListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetCustomerMessageById")]
        public async Task<ActionResult<CustomerMessageDetailVm>> GetCustomerMessageById(Guid id)
        {
            var getCustomerMessageDetailQuery = new GetCustomerMessageDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getCustomerMessageDetailQuery));
        }

    }
}
