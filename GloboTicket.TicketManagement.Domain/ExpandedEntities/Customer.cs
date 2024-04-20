using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GloboTicket.TicketManagement.Domain.Entities
{
    public partial class Customer
    {
        [NotMapped]
        public decimal Rating { get; set; }
        [NotMapped]
        public decimal CommentCount { get; set; }
        [NotMapped]
        public ICollection<SimleCategoryType> CategoryTypeNames { get; set; }
    }
}
