using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Features.States.Queries.GetStateQueryList;
using GloboTicket.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Localizations.Queries.GetLocalizationQueryList
{
    public class GetCityListQueryHandler : IRequestHandler<GetCityListQuery, List<CityListVm>>
    {
        private readonly IAsyncRepository<City> _stateRepository;
        private readonly IMapper _mapper;

        public GetCityListQueryHandler(IMapper mapper, IAsyncRepository<City> stateRepository)
        {
            _mapper = mapper;
            _stateRepository = stateRepository;
        }

        public async Task<List<CityListVm>> Handle(GetCityListQuery request, CancellationToken cancellationToken)
        {
            var allStates = (await _stateRepository.ListAllAsync());
            return _mapper.Map<List<CityListVm>>(allStates);
        }
    }
}
