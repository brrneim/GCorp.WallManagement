using GloboTicket.TicketManagement.Application.Features.Customers.Queries.GetCustomerRatingList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.Customers.Queries.GetCustomerCommentList
{
    public class GetCustomerCommentsListQuery : IRequest<List<CustomerCommentsListVm>>
    {
        public Guid CustomerId { get; set; }
    }
}
