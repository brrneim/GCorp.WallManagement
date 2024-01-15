using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Models.Dtos
{
    public class CountyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
    }
}
