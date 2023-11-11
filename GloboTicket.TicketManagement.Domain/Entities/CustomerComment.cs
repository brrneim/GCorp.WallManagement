using GloboTicket.TicketManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Domain.Entities
{
    public class CustomerComment : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CommentCustomerId { get; set; }
        public string Comment { get; set; }
        public Guid? WorkId { get; set; }
    }
}
