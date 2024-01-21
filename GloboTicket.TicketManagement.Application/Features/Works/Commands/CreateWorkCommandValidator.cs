using FluentValidation;
using GloboTicket.TicketManagement.Application.Features.Customers.Commands.CreateCustomer;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.Works.Commands
{
    public class CreateWorkCommandValidator : AbstractValidator<CreateWorkCommand>
    {
        public CreateWorkCommandValidator()
        {
            RuleFor(p => p.CustomerId)
                .NotEmpty().WithMessage("{CustomerId} is required.")
                .NotNull();
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{Description} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{Description} must not exceed 50 characters.");
            RuleFor(p => p.CityId)
               .NotEmpty().WithMessage("{CityId} is required.")
               .NotNull();
            RuleFor(p => p.CountyId)
               .NotEmpty().WithMessage("{CountyId} is required.")
               .NotNull();
        }
    }
}
