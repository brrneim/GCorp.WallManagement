using System;

namespace GloboTicket.TicketManagement.App.ViewModels
{
    public class CreateCustomerMessageModel
    {
        public string Message { get; set; }
        public Guid? WorkId { get; set; }
        public Guid CustomerSenderId { get; set; }
        public Guid CustomerRecieverId { get; set; }
        public bool IsRead { get; set; }
    }
}
