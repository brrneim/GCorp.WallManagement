using MediatR;
using System;

namespace GloboTicket.TicketManagement.Application.Features.Ratings.Commands.CreateRating
{
    public class CreateRatingCommand: IRequest<CreateRatingCommandResponse>
    {
        public Guid CustomerId { get; set; }
        public Guid RatingCustomerId { get; set; }
        public string Value { get; set; }
    }
}
