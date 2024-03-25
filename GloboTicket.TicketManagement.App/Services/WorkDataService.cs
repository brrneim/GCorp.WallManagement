using AutoMapper;
using Blazored.LocalStorage;
using GloboTicket.TicketManagement.App.Contracts;
using GloboTicket.TicketManagement.App.Services.Base;
using GloboTicket.TicketManagement.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.App.Services
{
    public class WorkDataService : BaseDataService, IWorkDataService
    {

        private readonly IMapper _mapper;

        public WorkDataService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<WorkListViewModel>> GetAllWorks()
        {
            var allWorks = await _client.GetAllWorksAsync();
            var mappedEvents = _mapper.Map<ICollection<WorkListViewModel>>(allWorks);
            return mappedEvents.ToList();
        }

        public async Task<WorkViewModel> GetWork(Guid workId)
        {
            var work = await _client.GetWorkAsync(workId);
            var mappedEvent = _mapper.Map<WorkViewModel>(work);
            return mappedEvent;
        }

        public async Task<List<CityListViewModel>> GetAllCities()
        {
            var allWorks = await _client.GetAllCitiesAsync();
            var mappedEvents = _mapper.Map<ICollection<CityListViewModel>>(allWorks);
            return mappedEvents.ToList();
        }

        public async Task<List<CountyListViewModel>> GetAllCounties(int cityId)
        {
            var allWorks = await _client.GetAllCountiesAsync(cityId);
            var mappedEvents = _mapper.Map<ICollection<CountyListViewModel>>(allWorks);
            return mappedEvents.ToList();
        }

        public async Task<System.Guid> CreateWorkModel(CreateWorkModel createWorkModel)
        {
            var workId = await _client.CreateWorkAsync(createWorkModel);
            return workId;
        }

    }
}
