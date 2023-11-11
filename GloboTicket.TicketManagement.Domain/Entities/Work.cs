using GloboTicket.TicketManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Domain.Entities
{
    public class Work : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid CustomerId { get; set; }
        public int CityId { get; set; }
        public int CountyId { get; set; }
        public string LocationX { get; set; }
        public string LocationY { get; set; }
        public Guid? DealCustomerId { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool IsActive { get; set; }
        public Guid StateId { get; set; }
    }
}
