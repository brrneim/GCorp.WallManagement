using GloboTicket.TicketManagement.Application.Features.Works.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.WorkCategory.Commands
{
    public class CreateWorkCategoryCommand : IRequest<CreateWorkCategoryCommandResponse>
    {
        public Guid Id { get; set; }
        public Guid WorkId { get; set; }
        public Guid CategoryTypeId { get; set; }
    }
}
