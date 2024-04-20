using GloboTicket.TicketManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GloboTicket.TicketManagement.Domain.Entities
{
    public class CustomerRating : AuditableEntity
    {
        public Guid Id { get; set; }
        [ForeignKey(nameof(Customer)), Column(Order = 0)]
        public Guid CustomerId { get; set; }
        [ForeignKey(nameof(RatingCustomer)), Column(Order = 1)]
        public Guid RatingCustomerId { get; set; }
        public decimal Value { get; set; }

       
        public virtual Customer Customer{ get; set; }
        public virtual Customer RatingCustomer { get; set; }

    }
}
