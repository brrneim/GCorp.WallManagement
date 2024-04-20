using GloboTicket.TicketManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Domain.Entities
{
    public class CustomerCategoryType : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CategoryTypeId { get; set; }

        public CategoryType CategoryType { get; set; }
        public Customer Customer { get; set; }

    }
}
