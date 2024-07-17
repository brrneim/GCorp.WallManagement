using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Features.Works.Commands;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GloboTicket.TicketManagement.Application.Features.WorkCategory.Commands
{
    public class CreateWorkCategoryCommandHandler : IRequestHandler<CreateWorkCategoryCommand, CreateWorkCategoryCommandResponse>
    {
        private readonly IAsyncRepository<WorkCategoryType> _workCategoryRepository;
        private readonly IMapper _mapper;

        public CreateWorkCategoryCommandHandler(IMapper mapper, IAsyncRepository<WorkCategoryType> workCategoryRepository)
        {
            _mapper = mapper;
            _workCategoryRepository = workCategoryRepository;
        }

        public async Task<CreateWorkCategoryCommandResponse> Handle(CreateWorkCategoryCommand request, CancellationToken cancellationToken)
        {
            var createWorkCategoryCommandResponse = new CreateWorkCategoryCommandResponse();
            var workCategoryType = new WorkCategoryType()
            {
                CategoryTypeId = request.CategoryTypeId,
                WorkId = request.WorkId
            };
            workCategoryType = await _workCategoryRepository.AddAsync(workCategoryType);
            createWorkCategoryCommandResponse.WorkCategory = _mapper.Map<CreateWorkCategoryDto>(workCategoryType);


            return createWorkCategoryCommandResponse;
        }

    }
}
