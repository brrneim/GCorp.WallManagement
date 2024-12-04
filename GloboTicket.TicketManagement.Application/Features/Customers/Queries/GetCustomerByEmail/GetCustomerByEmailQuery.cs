using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Customers.Queries.GetCustomerByEmail
{
    public class GetCustomerByEmailQuery : IRequest<CustomerIdByEmailVm>
    {
        public string Email { get; set; }
    }
    
}
