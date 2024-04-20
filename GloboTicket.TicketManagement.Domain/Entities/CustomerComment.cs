using GloboTicket.TicketManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GloboTicket.TicketManagement.Domain.Entities
{
    public class CustomerComment : AuditableEntity
    {
        public Guid Id { get; set; }
        [ForeignKey(nameof(Customer)), Column(Order = 0)]
        public Guid CustomerId { get; set; }
        [ForeignKey(nameof(CommentCustomer)), Column(Order = 1)]
        public Guid CommentCustomerId { get; set; }
        public string Comment { get; set; }
        public Guid? WorkId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Customer CommentCustomer { get; set; }


    }
}
