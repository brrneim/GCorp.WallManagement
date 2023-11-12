using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using GloboTicket.TicketManagement.Application.Features.CategoryTypes.Queries.GetCategoryTypeList;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.States.Queries.GetStateQueryList
{
    public class GetStateListQueryHandler : IRequestHandler<GetStateListQuery, List<StateListVm>>
    {
        private readonly IAsyncRepository<State> _stateRepository;
        private readonly IMapper _mapper;

        public GetStateListQueryHandler(IMapper mapper, IAsyncRepository<State> stateRepository)
        {
            _mapper = mapper;
            _stateRepository = stateRepository;
        }

        public async Task<List<StateListVm>> Handle(GetStateListQuery request, CancellationToken cancellationToken)
        {
            var allStates = (await _stateRepository.ListAllAsync());
            return _mapper.Map<List<StateListVm>>(allStates);
        }
    }
}
