using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Exceptions;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Works.Queries.GetWorkDetail
{
    public class GetWorkDetailQueryHandler : IRequestHandler<GetWorkDetailQuery, WorkDetailVm>
    {
        private readonly IAsyncRepository<Work> _workRepository;
        private readonly IMapper _mapper;

        public GetWorkDetailQueryHandler(IMapper mapper, IAsyncRepository<Work> workRepository)
        {
            _mapper = mapper;
            _workRepository = workRepository;
        }

        public async Task<WorkDetailVm> Handle(GetWorkDetailQuery request, CancellationToken cancellationToken)
        {
            var @work = await _workRepository.GetByIdAsync(request.Id);
            var workDetailDto = _mapper.Map<WorkDetailVm>(@work);


            if (workDetailDto == null)
            {
                throw new NotFoundException(nameof(work), request.Id);
            }

            return workDetailDto;
        }

    }
}
