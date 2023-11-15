using GloboTicket.TicketManagement.Application.Responses;

namespace GloboTicket.TicketManagement.Application.Features.Ratings.Commands.CreateRating
{
    public class CreateRatingCommandResponse : BaseResponse
    {
        public CreateRatingCommandResponse(): base()
        {

        }

        public CreateRatingDto Category { get; set; }
    }
}