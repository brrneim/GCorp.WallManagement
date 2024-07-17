using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.WorkCategory.Commands
{
    public class CreateWorkCategoryDto
    {
        public Guid Id { get; set; }
        public Guid WorkId { get; set; }
        public Guid CategoryTypeId { get; set; }
    }
}
