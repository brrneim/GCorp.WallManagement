using GloboTicket.TicketManagement.Application.Features.Works.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.CustomerMessages.Commands
{
    public class CreateCustomerMessageCommand : IRequest<CreateCustomerMessageCommandResponse>
    {
        public string Message { get; set; }
        public Guid? WorkId { get; set; }
        public Guid CustomerSenderId { get; set; }
        public Guid CustomerRecieverId { get; set; }
        public bool IsRead { get; set; }

    }
}
