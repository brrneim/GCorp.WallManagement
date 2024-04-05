using System;

namespace GloboTicket.TicketManagement.App.ViewModels
{
    public class WorkListViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime ExpireDate { get; set; }   
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
