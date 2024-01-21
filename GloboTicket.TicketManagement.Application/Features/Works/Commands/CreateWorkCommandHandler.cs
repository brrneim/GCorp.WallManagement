using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace GloboTicket.TicketManagement.Application.Features.Works.Commands
{
    public class CreateWorkCommandHandler : IRequestHandler<CreateWorkCommand, CreateWorkCommandResponse>
    {
        private readonly IAsyncRepository<Work> _workRepository;
        private readonly IMapper _mapper;

        public CreateWorkCommandHandler(IMapper mapper, IAsyncRepository<Work> workRepository)
        {
            _mapper = mapper;
            _workRepository = workRepository;
        }

        public async Task<CreateWorkCommandResponse> Handle(CreateWorkCommand request, CancellationToken cancellationToken)
        {
            var createWorkCommandResponse = new CreateWorkCommandResponse();

            var validator = new CreateWorkCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createWorkCommandResponse.Success = false;
                createWorkCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createWorkCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createWorkCommandResponse.Success)
            {
                var work = new Work()
                {
                    Description = request.Description,
                    CustomerId = request.CustomerId,
                    LocationX = request.LocationX,
                    LocationY = request.LocationY,
                    DealCustomerId = request.DealCustomerId,
                    ExpireDate = request.ExpireDate,
                    IsActive = request.IsActive,
                    StateId = request.StateId,
                    CityId = request.CityId,
                    CountyId = request.CountyId
                };
                work = await _workRepository.AddAsync(work);
                createWorkCommandResponse.Work = _mapper.Map<CreateWorkDto>(work);
            }

            return createWorkCommandResponse;
        }
    }
}
