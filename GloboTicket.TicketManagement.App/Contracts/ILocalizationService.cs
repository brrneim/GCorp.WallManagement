using GloboTicket.TicketManagement.App.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.App.Contracts
{
    public interface ILocalizationService
    {
        Task<List<CityListViewModel>> GetAllCities();
    }
}
