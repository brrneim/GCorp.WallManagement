using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Ratings.Queries.GetCustomerRatingList
{
    public class GetCustomerRatingsListQueryHandler : IRequestHandler<GetCustomerRatingsListQuery, List<CustomerRatingsListVm>>
    {
        private readonly IAsyncRepository<CustomerRating> _customerRatingRepository;
        private readonly IMapper _mapper;

        public GetCustomerRatingsListQueryHandler(IMapper mapper, IAsyncRepository<CustomerRating> customerRatingRepository)
        {
            _mapper = mapper;
            _customerRatingRepository = customerRatingRepository;
        }

        public async Task<List<CustomerRatingsListVm>> Handle(GetCustomerRatingsListQuery request, CancellationToken cancellationToken)
        {
            var allCustomerRatings = (await _customerRatingRepository.ListAllAsync()).OrderByDescending(x => x.CreatedDate);
            return _mapper.Map<List<CustomerRatingsListVm>>(allCustomerRatings);
        }
    }
}
