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
using System.Linq;

namespace GloboTicket.TicketManagement.Application.Features.Works.Queries.GetWorkList
{
    public class GetWorkListQueryHandler : IRequestHandler<GetWorkListQuery, List<WorkListVm>>
    {
        private readonly IAsyncRepository<Work> _workRepository;
        private readonly IMapper _mapper;

        public GetWorkListQueryHandler(IMapper mapper, IAsyncRepository<Work> workRepository)
        {
            _mapper = mapper;
            _workRepository = workRepository;
        }

        public async Task<List<WorkListVm>> Handle(GetWorkListQuery request, CancellationToken cancellationToken)
        {
            var allCategoryTpes = (await _workRepository.ListAllAsync());
            return _mapper.Map<List<WorkListVm>>(allCategoryTpes);
        }
    }
}
