using GloboTicket.TicketManagement.Application.Features.Customers.Queries.GetCustomerList;
using GloboTicket.TicketManagement.Application.Features.Works.Queries.GetWorkList;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.Customers.Queries.GetCustomerListByFilter
{

    public class PagedCustomerListByFilterVm
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public ICollection<CustomerListVm> CustomerFilterDto { get; set; }
    }
}
