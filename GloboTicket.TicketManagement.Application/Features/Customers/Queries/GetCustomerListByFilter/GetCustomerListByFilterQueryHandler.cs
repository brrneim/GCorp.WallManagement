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
using GloboTicket.TicketManagement.Application.Features.Customers.Queries.GetCustomerList;

namespace  GloboTicket.TicketManagement.Application.Features.Customers.Queries.GetCustomerListByFilter
{
    public class GetCustomerListByFilterQueryHandler : IRequestHandler<GetCustomerListByFilterQuery, PagedCustomerListByFilterVm>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerListByFilterQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        //public async Task<List<WorkListVm>> Handle(GetWorkListByFilterQuery request, CancellationToken cancellationToken)
        //{
        //    var allWorks = (await _workRepository.ListAllAsync());
        //    return _mapper.Map<List<WorkListVm>>(allWorks);
        //}

        public async Task<PagedCustomerListByFilterVm> Handle(GetCustomerListByFilterQuery request, CancellationToken cancellationToken)
        {
            var list = await _customerRepository.GetCustomersByFilter(request.CustomerFilterDto.CityId
                , request.CustomerFilterDto.CountyId, request.CustomerFilterDto.CategoryId
                , request.CustomerFilterDto.Page, request.CustomerFilterDto.Size);

            var customers = _mapper.Map<List<CustomerListVm>>(list);
           

            var count = await _customerRepository.GetTotalCountOfCustomersWithFilter(request.CustomerFilterDto.CityId
                , request.CustomerFilterDto.CountyId, request.CustomerFilterDto.CategoryId);

            return new PagedCustomerListByFilterVm() { Count = count, CustomerFilterDto = customers, Page = request.CustomerFilterDto.Page, Size = request.CustomerFilterDto.Size };

        }

    }
}
