using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Localizations.Queries.GetLocalizationQueryList
{
    public class GetCountyListQueryHandler : IRequestHandler<GetCountyListQuery, List<CountyListVm>>
    {
        private readonly IAsyncRepository<County> _stateRepository;
        private readonly IMapper _mapper;

        public GetCountyListQueryHandler(IMapper mapper, IAsyncRepository<County> stateRepository)
        {
            _mapper = mapper;
            _stateRepository = stateRepository;
        }

        public async Task<List<CountyListVm>> Handle(GetCountyListQuery request, CancellationToken cancellationToken)
        {
            var allStates = (await _stateRepository.ListAllAsync());
            return _mapper.Map<List<CountyListVm>>(allStates);
        }
    }
}
