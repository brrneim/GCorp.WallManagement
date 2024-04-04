using GloboTicket.TicketManagement.Application.Features.Works.Queries.GetWorkList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.Works.Queries.GetWorkListByFilter
{

    public class GetWorkListByFilterQuery : IRequest<List<WorkListVm>>
    {
        public WorkFilterDto WorkFilterDto { get; set; }
    }
}
