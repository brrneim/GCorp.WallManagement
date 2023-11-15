using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.Messages.Queries.GetCustomerMessageList
{
    public class GetCustomerMessagesListQuery : IRequest<List<CustomerMessagesListVm>>
    {
        public Guid CustomerId { get; set; }
    }
}
