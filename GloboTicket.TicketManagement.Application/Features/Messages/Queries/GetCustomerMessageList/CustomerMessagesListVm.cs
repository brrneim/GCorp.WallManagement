﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.Messages.Queries.GetCustomerMessageList
{
    public class CustomerMessagesListVm
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public Guid? WorkId { get; set; }
        public Guid CustomerSenderId { get; set; }
        public Guid CustomerReceiverId { get; set; }
        public bool IsRead { get; set; }
    }
}
