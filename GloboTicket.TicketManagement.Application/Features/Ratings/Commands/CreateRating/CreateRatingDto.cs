using System;

namespace GloboTicket.TicketManagement.Application.Features.Ratings.Commands.CreateRating
{
    public class CreateRatingDto
    {
        public Guid CustomerId { get; set; }
        public Guid RatingCustomerId { get; set; }
        public string Value { get; set; }
    }
}
