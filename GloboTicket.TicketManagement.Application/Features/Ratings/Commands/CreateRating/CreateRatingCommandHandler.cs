using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Ratings.Commands.CreateRating
{
    public class CreateRatingCommandHandler : IRequestHandler<CreateRatingCommand, CreateRatingCommandResponse>
    {
        private readonly IAsyncRepository<CustomerRating> _customerRatingRepository;
        private readonly IMapper _mapper;

        public CreateRatingCommandHandler(IMapper mapper, IAsyncRepository<CustomerRating> customerRatingRepository)
        {
            _mapper = mapper;
            _customerRatingRepository = customerRatingRepository;
        }

        public async Task<CreateRatingCommandResponse> Handle(CreateRatingCommand request, CancellationToken cancellationToken)
        {
            var createRatingCommandResponse = new CreateRatingCommandResponse();

            var validator = new CreateRatingCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createRatingCommandResponse.Success = false;
                createRatingCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createRatingCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createRatingCommandResponse.Success)
            {
                var rating = new CustomerRating() { Value = request.Value };
                rating = await _customerRatingRepository.AddAsync(rating);
                createRatingCommandResponse.Category = _mapper.Map<CreateRatingDto>(rating);
            }

            return createRatingCommandResponse;
        }
    }
}
