using System.Collections.Generic;

namespace GloboTicket.TicketManagement.App.ViewModels
{
    public class PagedWorkListForFilterModel
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public ICollection<WorkListViewModel> WorkList { get; set; }
    }
}
