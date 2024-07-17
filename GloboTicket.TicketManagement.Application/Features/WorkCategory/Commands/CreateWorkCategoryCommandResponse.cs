using GloboTicket.TicketManagement.Application.Features.Works.Commands;
using GloboTicket.TicketManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.WorkCategory.Commands
{
    public class CreateWorkCategoryCommandResponse : BaseResponse
    {
        public CreateWorkCategoryCommandResponse() : base()
        {

        }

        public CreateWorkCategoryDto WorkCategory { get; set; }
    }
}
