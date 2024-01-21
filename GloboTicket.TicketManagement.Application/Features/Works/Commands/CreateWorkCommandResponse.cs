using GloboTicket.TicketManagement.Application.Features.Customers.Commands.CreateCustomer;
using GloboTicket.TicketManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.Works.Commands
{
    public class CreateWorkCommandResponse : BaseResponse
    {
        public CreateWorkCommandResponse() : base()
        {

        }

        public CreateWorkDto Work { get; set; }
    }
}
