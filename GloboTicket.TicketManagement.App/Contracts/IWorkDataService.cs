using GloboTicket.TicketManagement.App.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.App.Contracts
{
    public interface IWorkDataService
    {
        Task<List<WorkListViewModel>> GetAllWorks();

        List<CityListModel> GetAllCities();

        List<CountyListModel> GetAllCounty(int cityId);

        List<CountyListModel> GetAllCountyByCountyId(int CountyId);

        Task<List<CategoryListModel>> GetCategories();

        Task<List<WorkListViewModel>> GetWorksWithFilters(FilterViewModel filterViewModel);

    }
}
