using GloboTicket.TicketManagement.Application.Features.Works.Queries.GetWorkList;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.Works.Queries.GetWorkListByFilter
{

    public class PagedWorkListByFilterVm
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public ICollection<WorkListVm> WorkListByFilter { get; set; }
    }
}
