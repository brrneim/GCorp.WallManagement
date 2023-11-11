using GloboTicket.TicketManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Domain.Entities
{
    public class CustomerMessage : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public Guid? WorkId { get; set; }
        public Guid CustomerSenderId { get; set; }
        public Guid CustomerReceiverId { get; set; }
        public bool IsRead { get; set; }
    }
}
