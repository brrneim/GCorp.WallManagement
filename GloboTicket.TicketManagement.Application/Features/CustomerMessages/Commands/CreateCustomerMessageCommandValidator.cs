using FluentValidation;
using GloboTicket.TicketManagement.Application.Features.Works.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.CustomerMessages.Commands
{
    public class CreateCustomerMessageCommandValidator : AbstractValidator<CreateCustomerMessageCommand>
    {
        public CreateCustomerMessageCommandValidator()
        {
            RuleFor(p => p.CustomerRecieverId)
                .NotEmpty().WithMessage("{CustomerRecieverId} is required.")
                .NotNull();
            RuleFor(p => p.CustomerSenderId)
                .NotEmpty().WithMessage("{CustomerSenderId} is required.")
                .NotNull();
        }
    }
}
