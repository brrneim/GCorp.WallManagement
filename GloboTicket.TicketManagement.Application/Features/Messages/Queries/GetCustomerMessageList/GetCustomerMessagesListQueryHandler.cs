using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Messages.Queries.GetCustomerMessageList
{
    public class GetCustomerMessagesListQueryHandler : IRequestHandler<GetCustomerMessagesListQuery, List<CustomerMessagesListVm>>
    {
        private readonly ICustomerMessageRepository _customerMessagesRepository;
        private readonly IMapper _mapper;

        public GetCustomerMessagesListQueryHandler(IMapper mapper, ICustomerMessageRepository customerMessagesRepository)
        {
            _mapper = mapper;
            _customerMessagesRepository = customerMessagesRepository;
        }

        public async Task<List<CustomerMessagesListVm>> Handle(GetCustomerMessagesListQuery request, CancellationToken cancellationToken)
        {
            var allCustomerMessages = (await _customerMessagesRepository.GetMessagesByCustomerId(request.CustomerId)).OrderBy(x => x.CreatedDate);

            return _mapper.Map<List<CustomerMessagesListVm>>(allCustomerMessages);
           
        }
    }
}
