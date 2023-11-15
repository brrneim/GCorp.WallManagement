using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Features.Customers.Queries.GetCustomerRatingList;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Customers.Queries.GetCustomerCommentList
{
    public class GetCustomerCommentsListQueryHandler : IRequestHandler<GetCustomerCommentsListQuery, List<CustomerCommentsListVm>>
    {
        private readonly ICustomerCommentRepository _customerCommentRepository;
        private readonly IMapper _mapper;

        public GetCustomerCommentsListQueryHandler(IMapper mapper, ICustomerCommentRepository customerCommentRepository)
        {
            _mapper = mapper;
            _customerCommentRepository = customerCommentRepository;
        }

        public async Task<List<CustomerCommentsListVm>> Handle(GetCustomerCommentsListQuery request, CancellationToken cancellationToken)
        {
            var allCustomerComments = (await _customerCommentRepository.GetCommentsByCustomerId(request.CustomerId)).OrderBy(x => x.CreatedDate);
        
            return _mapper.Map<List<CustomerCommentsListVm>>(allCustomerComments);
        }

       
    }
}
