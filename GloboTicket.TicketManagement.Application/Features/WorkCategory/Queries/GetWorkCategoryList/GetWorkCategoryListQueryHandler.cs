using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Features.Works.Queries.GetWorkList;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GloboTicket.TicketManagement.Application.Features.WorkCategory.Queries.GetWorkCategoryList
{
    public class GetWorkCategoryListQueryHandler : IRequestHandler<GetWorkCategoryListQuery, List<WorkCategoryListVm>>
    {
        private readonly IAsyncRepository<WorkCategoryType> _workCategoryRepository;
        private readonly IMapper _mapper;

        public GetWorkCategoryListQueryHandler(IMapper mapper, IAsyncRepository<WorkCategoryType> workCategoryRepository)
        {
            _mapper = mapper;
            _workCategoryRepository = workCategoryRepository;
        }

        public async Task<List<WorkCategoryListVm>> Handle(GetWorkCategoryListQuery request, CancellationToken cancellationToken)
        {
            var allCategoryTpes = (await _workCategoryRepository.ListAllAsync());
            return _mapper.Map<List<WorkCategoryListVm>>(allCategoryTpes);
        }
    }
}
