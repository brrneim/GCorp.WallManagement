using GloboTicket.TicketManagement.Application.Contracts.Identity;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Features.Customers.Commands.CreateCustomer;
using GloboTicket.TicketManagement.Application.Models.Authentication;
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
        private readonly IMediator _mediator;
        private readonly IHashOperation _hashOperation;

        public AccountController(IAuthenticationService authenticationService, IMediator mediator, IHashOperation hashOperation)
        {
            _authenticationService = authenticationService;
            _mediator = mediator;
            _hashOperation = hashOperation;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _authenticationService.AuthenticateAsync(request));
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
                   PhoneNumber = request.PhoneNumber
            };
            var responseCustomer = await _mediator.Send(createCustomerCommand);

            return Ok(response);
        }
      
    }
}
