using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.Works.Queries.GetWorkDetail
{
    public class WorkDetailVm
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CityId { get; set; }
        public Guid CountyId { get; set; }
        public string LocationX { get; set; }
        public string LocationY { get; set; }
        public Guid DealCustomerId { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool IsActive { get; set; }
        public Guid StateId { get; set; }
    }
}
