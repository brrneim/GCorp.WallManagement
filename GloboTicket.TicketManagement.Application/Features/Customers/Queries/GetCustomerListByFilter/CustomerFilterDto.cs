using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.Customers.Queries.GetCustomerListByFilter
{
    public class CustomerFilterDto
    {
        public decimal LocationX { get; set; }
        public decimal LocationY { get; set; }
        public Guid CityId { get; set; }
        public Guid CountyId { get; set; }
        public Guid CategoryId { get; set; }

        public int Page { get; set; }
        public int Size { get; set; }
    }
}
