﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Contracts.Infrastructure
{
    public interface IHashOperation
    {
        string  HashPassword(string password);
    }
}
