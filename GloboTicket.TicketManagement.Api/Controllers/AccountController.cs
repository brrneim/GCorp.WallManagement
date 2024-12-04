using GloboTicket.TicketManagement.Application.Contracts.Identity;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Features.Customers.Commands.CreateCustomer;
using GloboTicket.TicketManagement.Application.Models.Authentication;
using GloboTicket.TicketManagement.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;


namespace GloboTicket.TicketManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediator _mediator;
        private readonly IHashOperation _hashOperation;

        public AccountController(IAuthenticationService authenticationService, ICustomerRepository customerRepository, IMediator mediator, IHashOperation hashOperation)
        {
            _authenticationService = authenticationService;
            _mediator = mediator;
            _hashOperation = hashOperation;
            _customerRepository = customerRepository;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            var response = await _authenticationService.AuthenticateAsync(request);
            var customer = await _customerRepository.GetCustomerByEmail(response.Email);
            response.CustomerId = customer.Id;
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegistrationRequest request)
        {
            var response = await _authenticationService.RegisterAsync(request);

            var createCustomerCommand = new CreateCustomerCommand() { 
                   Name = request.FirstName,
                   Surname = request.LastName,
                   Mail  =request.Email,
                   Username = request.UserName,
                   Password = _hashOperation.HashPassword(request.Password),
                   PhoneNumber = request.PhoneNumber,                   
            };
            var responseCustomer = await _mediator.Send(createCustomerCommand);
         
            return Ok(response);
        }
      
    }
}
