using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.WorkCategory.Queries.GetWorkCategoryList
{
    public class GetWorkCategoryListQuery : IRequest<List<WorkCategoryListVm>>
    {
    }
}
