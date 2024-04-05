using GloboTicket.TicketManagement.Application.Features.Works.Commands;
using GloboTicket.TicketManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.CustomerMessages.Commands
{
    public class CreateCustomerMessageCommandResponse : BaseResponse
    {
        public CreateCustomerMessageCommandResponse() : base()
        {

        }

        public CreateCustomerMessageDto CreateCustomerMessage { get; set; }
    }
}
