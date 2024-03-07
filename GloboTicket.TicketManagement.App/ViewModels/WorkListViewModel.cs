using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.App.ViewModels
{
    public class WorkListViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime ExpireDate { get; set; }   

    }
}
