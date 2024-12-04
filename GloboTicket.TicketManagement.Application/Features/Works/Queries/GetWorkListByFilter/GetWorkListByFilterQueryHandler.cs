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
using GloboTicket.TicketManagement.Application.Features.Orders.GetOrdersForMonth;

namespace GloboTicket.TicketManagement.Application.Features.Works.Queries.GetWorkListByFilter
{
    public class GetWorkListByFilterQueryHandler : IRequestHandler<GetWorkListByFilterQuery, PagedWorkListByFilterVm>
    {
        private readonly IWorkRepository _workRepository;
        private readonly IMapper _mapper;

        public GetWorkListByFilterQueryHandler(IMapper mapper, IWorkRepository workRepository)
        {
            _mapper = mapper;
            _workRepository = workRepository;
        }

        //public async Task<List<WorkListVm>> Handle(GetWorkListByFilterQuery request, CancellationToken cancellationToken)
        //{
        //    var allWorks = (await _workRepository.ListAllAsync());
        //    return _mapper.Map<List<WorkListVm>>(allWorks);
        //}

        public async Task<PagedWorkListByFilterVm> Handle(GetWorkListByFilterQuery request, CancellationToken cancellationToken)
        {
            var list = await _workRepository.GetWorksByFilter(request.WorkFilterDto.FromTime, request.WorkFilterDto.ToTime, request.WorkFilterDto.CityId
                , request.WorkFilterDto.CountyId, request.WorkFilterDto.CategoryId, request.WorkFilterDto.DealCustomerId
                , request.WorkFilterDto.Page, request.WorkFilterDto.Size);

            var works = _mapper.Map<List<WorkListVm>>(list);
           

            var count = await _workRepository.GetTotalCountOfWorksWithFilter(request.WorkFilterDto.FromTime
                , request.WorkFilterDto.ToTime, request.WorkFilterDto.CityId
                , request.WorkFilterDto.CountyId, request.WorkFilterDto.CategoryId, request.WorkFilterDto.DealCustomerId);

            return new PagedWorkListByFilterVm() { Count = count, WorkFilterDto = works, Page = request.WorkFilterDto.Page, Size = request.WorkFilterDto.Size };

        }

    }
}
