using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Models.Dtos
{
    public class CityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
    }
}
