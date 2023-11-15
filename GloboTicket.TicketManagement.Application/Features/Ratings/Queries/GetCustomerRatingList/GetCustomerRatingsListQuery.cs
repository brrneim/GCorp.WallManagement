using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.Ratings.Queries.GetCustomerRatingList
{
    public class GetCustomerRatingsListQuery : IRequest<List<CustomerRatingsListVm>>
    {
        public Guid CustomerId { get; set; }
    }
}
