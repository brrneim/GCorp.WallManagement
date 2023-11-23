using GloboTicket.TicketManagement.App.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.App.Contracts
{
    public interface IWorkDataService
    {
        Task<List<WorkListViewModel>> GetAllWorks();
    }
}
