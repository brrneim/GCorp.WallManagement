using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.Ratings.Queries.GetCustomerRatingList
{
    public class CustomerRatingsListVm
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid RatingCustomerId { get; set; }
        public string Value { get; set; }
    }
}
