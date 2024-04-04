using GloboTicket.TicketManagement.Application.Features.Works.Queries.GetWorkDetail;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.CustomerMessages.Queries.GetCustomerMessageDetail
{
    public class GetCustomerMessageDetailQuery : IRequest<CustomerMessageDetailVm>
    {
        public Guid Id { get; set; }
    }
}
