using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.CategoryTypes.Queries.GetCategoryTypeList
{
    public class GetCategoryTypeListQuery : IRequest<List<CategoryTypeListVm>>
    {
    }
}
