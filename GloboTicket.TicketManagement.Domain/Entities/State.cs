using GloboTicket.TicketManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Domain.Entities
{
    public class State : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
