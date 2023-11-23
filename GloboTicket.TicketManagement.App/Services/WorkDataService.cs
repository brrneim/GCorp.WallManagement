using AutoMapper;
using Blazored.LocalStorage;
using GloboTicket.TicketManagement.App.Contracts;
using GloboTicket.TicketManagement.App.Services.Base;
using GloboTicket.TicketManagement.App.ViewModels;
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

    }
}
