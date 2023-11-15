using FluentValidation;

namespace GloboTicket.TicketManagement.Application.Features.Ratings.Commands.CreateRating
{
    public class CreateRatingCommandValidator: AbstractValidator<CreateRatingCommand>
    {
        public CreateRatingCommandValidator()
        {
            RuleFor(p => p.Value)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
