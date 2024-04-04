using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Exceptions;
using GloboTicket.TicketManagement.Application.Features.Works.Queries.GetWorkDetail;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GloboTicket.TicketManagement.Application.Features.CustomerMessages.Queries.GetCustomerMessageDetail
{
    public class GetCustomerMessageDetailQueryHandler : IRequestHandler<GetCustomerMessageDetailQuery, CustomerMessageDetailVm>
    {
        private readonly IAsyncRepository<CustomerMessage> _customerMessageRepository;
        private readonly IMapper _mapper;

        public GetCustomerMessageDetailQueryHandler(IMapper mapper, IAsyncRepository<CustomerMessage> customerMessageRepository)
        {
            _mapper = mapper;
            _customerMessageRepository = customerMessageRepository;
        }

        public async Task<CustomerMessageDetailVm> Handle(GetCustomerMessageDetailQuery request, CancellationToken cancellationToken)
        {
            var @customerMessage = await _customerMessageRepository.GetByIdAsync(request.Id);
            var customerMessageDetailDto = _mapper.Map<CustomerMessageDetailVm>(@customerMessage);


            if (customerMessageDetailDto == null)
            {
                throw new NotFoundException(nameof(@customerMessage), request.Id);
            }

            return customerMessageDetailDto;
        }

    }
}
