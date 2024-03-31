using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.CustomerMessages.Queries.GetCustomerMessageList
{
    public class CustomerMessageListVm
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public Guid? WorkId { get; set; }
        public Guid CustomerSenderId { get; set; }
        public Guid CustomerRecieverId { get; set; }
        public bool IsRead { get; set; }
    }
}
