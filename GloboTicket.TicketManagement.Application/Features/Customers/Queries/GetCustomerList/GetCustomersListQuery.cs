using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.Customers.Queries.GetCustomerList
{
    public class GetCustomersListQuery : IRequest<List<CustomerListVm>>
    {
    }
}
