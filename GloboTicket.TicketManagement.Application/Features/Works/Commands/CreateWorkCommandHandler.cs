using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace GloboTicket.TicketManagement.Application.Features.Works.Commands
{
    public class CreateWorkCommandHandler : IRequestHandler<CreateWorkCommand, Guid>
    {
        private readonly IAsyncRepository<Work> _workRepository;
        private readonly IMapper _mapper;

        public CreateWorkCommandHandler(IMapper mapper, IAsyncRepository<Work> workRepository)
        {
            _mapper = mapper;
            _workRepository = workRepository;
        }

        public async Task<Guid> Handle(CreateWorkCommand request, CancellationToken cancellationToken)
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


            return work.Id;
        }
    }
}
