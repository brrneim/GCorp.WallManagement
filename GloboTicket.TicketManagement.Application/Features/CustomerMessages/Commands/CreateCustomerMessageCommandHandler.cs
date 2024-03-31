using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace GloboTicket.TicketManagement.Application.Features.CustomerMessages.Commands
{
    public class CreateCustomerMessageCommandHandler : IRequestHandler<CreateCustomerMessageCommand, CreateCustomerMessageCommandResponse>
    {
        private readonly IAsyncRepository<CustomerMessage> _workRepository;
        private readonly IMapper _mapper;

        public CreateCustomerMessageCommandHandler(IMapper mapper, IAsyncRepository<CustomerMessage> workRepository)
        {
            _mapper = mapper;
            _workRepository = workRepository;
        }

        public async Task<CreateCustomerMessageCommandResponse> Handle(CreateCustomerMessageCommand request, CancellationToken cancellationToken)
        {
            var createWorkCommandResponse = new CreateCustomerMessageCommandResponse();

            var validator = new CreateCustomerMessageCommandValidator();
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
                var customerMessage = new CustomerMessage()
                {
                    Message = request.Message,
                    CustomerReceiverId = request.CustomerRecieverId,
                    CustomerSenderId = request.CustomerSenderId,
                    WorkId = request.WorkId,
                    IsRead = request.IsRead
                };
                customerMessage = await _workRepository.AddAsync(customerMessage);
                createWorkCommandResponse.CreateCustomerMessage = _mapper.Map<CreateCustomerMessageDto>(customerMessage);
            }

            return createWorkCommandResponse;
        }
    }
}
