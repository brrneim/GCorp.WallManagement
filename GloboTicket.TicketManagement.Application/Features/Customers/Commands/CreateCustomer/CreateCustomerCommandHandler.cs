using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandResponse>
    {
        private readonly IAsyncRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(IMapper mapper, IAsyncRepository<Customer> customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var createCustomerCommandResponse = new CreateCustomerCommandResponse();

            var validator = new CreateCustomerCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createCustomerCommandResponse.Success = false;
                createCustomerCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createCustomerCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createCustomerCommandResponse.Success)
            {
                var customer = new Customer()
                {
                    Name = request.Name,
                    CityId = request.CityId,
                    CompanyName = request.CompanyName,
                    PhoneNumber = request.PhoneNumber,
                    CompanyPictureUrl = request.CompanyPictureUrl,
                    CountyId = request.CountyId,
                    InstagramLink = request.InstagramLink,
                    TiktokLink = request.TiktokLink,
                    Title = request.Title,
                    FacebookLink = request.FacebookLink,
                    Mail = request.Mail,
                    TwitterLink = request.TwitterLink,
                    LocationX = request.LocationX,
                    LocationY = request.LocationY,
                    Password = request.Password,
                    LinkedInLink = request.LinkedInLink,
                    Surname = request.Surname,
                    Username = request.Username,
                    PictureUrl = request.PictureUrl

                };
                customer = await _customerRepository.AddAsync(customer);
                createCustomerCommandResponse.Customer = _mapper.Map<CreateCustomerDto>(customer);
            }

            return createCustomerCommandResponse;
        }
    }
}
