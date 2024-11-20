using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using GloboTicket.TicketManagement.Application.Features.Customers.Commands.CreateCustomer;
using GloboTicket.TicketManagement.Application.Features.Customers.Queries.GetCustomerByEmail;
using GloboTicket.TicketManagement.Application.Features.Customers.Queries.GetCustomerList;
using GloboTicket.TicketManagement.Application.Features.Customers.Queries.GetCustomerListByFilter;
using GloboTicket.TicketManagement.Application.Features.Customers.Queries.GetCustomerRatingList;
using GloboTicket.TicketManagement.Application.Features.Messages.Queries.GetCustomerMessageList;
using GloboTicket.TicketManagement.Application.Features.Works.Queries.GetWorkListByFilter;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CustomerListVm>>> GetAllCustomers()
        {
            var dtos = await _mediator.Send(new GetCustomersListQuery());
            return Ok(dtos);
        }

        [HttpGet("customerbyemail", Name = "GetCustomerByEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CustomerIdByEmailVm>> GetCustomerByEmail(string mail)
        {
            var dtos = await _mediator.Send(new GetCustomerByEmailQuery() {  Email = mail});
            return Ok(dtos);
        }

        [HttpGet("allRatings", Name = "GetAllRatingsByCustomerId")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryEventListVm>>> GetCustomerRatings(Guid customerId)
        {
            GetCustomerMessagesListQuery getCustomerRatingsListQuery = new GetCustomerMessagesListQuery() { CustomerId  = customerId };

            var dtos = await _mediator.Send(getCustomerRatingsListQuery);
            return Ok(dtos);
        }

        [HttpPost(Name = "AddCustomer")]
        public async Task<ActionResult<CreateCustomerCommandResponse>> Create([FromBody] CreateCustomerCommand createCustomerCommand)
        {
            var response = await _mediator.Send(createCustomerCommand);
            return Ok(response);
        }

        [HttpGet("allcustomersbyfilter", Name = "GetAllCustomersByFilter")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PagedCustomerListByFilterVm>> GetAllCustomersByFilter(Guid selectedCategoryId, Guid selectedCityId, Guid selectedCountyId, int page, int size)
        {
            CustomerFilterDto customerFilterDto = new CustomerFilterDto()
            {
                CategoryId = selectedCategoryId,
                CityId = selectedCityId,
                CountyId = selectedCountyId,
                Page = page,
                Size = size

            };

            var getCustomerListByFilterQuery = new GetCustomerListByFilterQuery() { CustomerFilterDto = customerFilterDto };

            var dtos = await _mediator.Send(getCustomerListByFilterQuery);
            return Ok(dtos);
        }

    }
}
