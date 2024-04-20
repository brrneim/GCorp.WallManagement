using GloboTicket.TicketManagement.Application.Features.Works.Queries.GetWorkList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.Customers.Queries.GetCustomerListByFilter
{

    public class GetCustomerListByFilterQuery : IRequest<PagedCustomerListByFilterVm>
    {
        public CustomerFilterDto CustomerFilterDto { get; set; }

    }
}
