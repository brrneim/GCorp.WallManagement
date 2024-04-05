using GloboTicket.TicketManagement.Application.Features.Localizations.Queries.GetLocalizationQueryList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.CustomerMessages.Queries.GetCustomerMessageList
{
    public class GetCustomerMessageListQuery : IRequest<List<CustomerMessageListVm>>
    {
    }
}
