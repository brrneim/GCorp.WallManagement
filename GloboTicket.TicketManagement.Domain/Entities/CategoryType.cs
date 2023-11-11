using GloboTicket.TicketManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Domain.Entities
{
    public class CategoryType : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid? MainCategoryTypeId { get; set; }
        public string Name { get; set; }
    }
}
