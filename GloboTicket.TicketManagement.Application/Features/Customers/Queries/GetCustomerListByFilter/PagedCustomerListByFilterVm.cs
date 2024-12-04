using GloboTicket.TicketManagement.Application.Features.Customers.Queries.GetCustomerList;
using System.Collections.Generic;

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
