using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.WorkCategory.Queries.GetWorkCategoryList
{
    public class WorkCategoryListVm
    {
        public Guid Id { get; set; }
        public Guid WorkId { get; set; }
        public Guid CategoryTypeId { get; set; }
    }
}
