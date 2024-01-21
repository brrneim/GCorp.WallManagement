using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.Works.Queries.GetWorkDetail
{
    public class GetWorkDetailQuery : IRequest<WorkDetailVm>
    {
        public Guid Id { get; set; }
    }
}
