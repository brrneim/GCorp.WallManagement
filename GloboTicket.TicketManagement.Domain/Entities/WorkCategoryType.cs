using GloboTicket.TicketManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Domain.Entities
{
    public class WorkCategoryType : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid WorkId { get; set; }
        public Guid CategoryTypeId { get; set; }
    }
}
