using System.Collections.Generic;

namespace GloboTicket.TicketManagement.App.ViewModels
{
    public class PagedCustomerListForFilterModel
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public ICollection<CustomerListViewModel> CustomerList { get; set; }
    }
}
