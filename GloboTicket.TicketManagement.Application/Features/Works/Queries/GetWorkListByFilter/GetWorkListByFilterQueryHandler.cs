using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Features.CategoryTypes.Queries.GetCategoryTypeList;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using GloboTicket.TicketManagement.Application.Features.Works.Queries.GetWorkList;

namespace GloboTicket.TicketManagement.Application.Features.Works.Queries.GetWorkListByFilter
{
    public class GetWorkListByFilterQueryHandler : IRequestHandler<GetWorkListByFilterQuery, List<WorkListVm>>
    {
        private readonly IAsyncRepository<Work> _workRepository;
        private readonly IMapper _mapper;

        public GetWorkListByFilterQueryHandler(IMapper mapper, IAsyncRepository<Work> workRepository)
        {
            _mapper = mapper;
            _workRepository = workRepository;
        }

        public async Task<List<WorkListVm>> Handle(GetWorkListByFilterQuery request, CancellationToken cancellationToken)
        {
            var allWorks = (await _workRepository.ListAllAsync());
            return _mapper.Map<List<WorkListVm>>(allWorks);
        }

    }
}
