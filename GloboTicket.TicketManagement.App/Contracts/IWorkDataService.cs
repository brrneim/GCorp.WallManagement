using GloboTicket.TicketManagement.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.App.Contracts
{
    public interface IWorkDataService
    {
        Task<List<WorkListViewModel>> GetAllWorks();
        Task<List<CityListViewModel>> GetAllCities();
        Task<List<CountyListViewModel>> GetAllCounties(int cityId);
        Task<System.Guid> CreateWorkModel(CreateWorkModel createWorkModel);
        Task<WorkViewModel> GetWork(Guid workId);
    }
}
