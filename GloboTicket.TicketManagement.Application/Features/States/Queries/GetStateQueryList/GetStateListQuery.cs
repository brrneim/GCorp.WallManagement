using GloboTicket.TicketManagement.Application.Features.CategoryTypes.Queries.GetCategoryTypeList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.States.Queries.GetStateQueryList
{
    public class GetStateListQuery : IRequest<List<StateListVm>>
    {
    }
}
