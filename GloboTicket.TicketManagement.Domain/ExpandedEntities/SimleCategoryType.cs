using System.ComponentModel.DataAnnotations.Schema;

namespace GloboTicket.TicketManagement.Domain.Entities
{
    [NotMapped]
    public class SimleCategoryType
    {
        public string Name { get; set; }
    }
}
