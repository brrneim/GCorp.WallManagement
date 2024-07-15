using System;

namespace GloboTicket.TicketManagement.App.ViewModels
{
    public class CustomerMessageListViewModel
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public Guid? WorkId { get; set; }
        public Guid CustomerSenderId { get; set; }
        public Guid CustomerReceiverId { get; set; }
        public bool IsRead { get; set; }
    }
}

