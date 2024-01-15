using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.Localizations.Queries.GetLocalizationQueryList
{
    public class GetCityListQuery : IRequest<List<CityListVm>>
    {
    }
}
