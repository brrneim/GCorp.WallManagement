using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GloboTicket.TicketManagement.Application.Features.CustomerMessages.Queries.GetCustomerMessageList
{
    public class GetCustomerMessageListQueryHandler : IRequestHandler<GetCustomerMessageListQuery, List<CustomerMessageListVm>>
    {
        private readonly IAsyncRepository<CustomerMessage> _customerMessageRepository;
        private readonly IMapper _mapper;

        public GetCustomerMessageListQueryHandler(IMapper mapper, IAsyncRepository<CustomerMessage> customerMessageRepositoryRepository)
        {
            _mapper = mapper;
            _customerMessageRepository = customerMessageRepositoryRepository;
        }

        public async Task<List<CustomerMessageListVm>> Handle(GetCustomerMessageListQuery request, CancellationToken cancellationToken)
        {
            var allCategoryTpes = (await _customerMessageRepository.ListAllAsync());
            return _mapper.Map<List<CustomerMessageListVm>>(allCategoryTpes);
        }
    }
}
