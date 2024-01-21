using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.Localizations.Queries.GetLocalizationQueryList
{
    public class CountyListVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
    }
}
