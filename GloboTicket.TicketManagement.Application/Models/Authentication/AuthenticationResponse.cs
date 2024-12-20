﻿using System;

namespace GloboTicket.TicketManagement.Application.Models.Authentication
{
    public class AuthenticationResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public Guid CustomerId { get; set; }
    }
}
