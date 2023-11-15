using GloboTicket.TicketManagement.Application.Features.CategoryTypes.Queries.GetCategoryTypeList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.Works.Queries.GetWorkList
{
    public class GetWorkListQuery : IRequest<List<WorkListVm>>
    {

    }
}
