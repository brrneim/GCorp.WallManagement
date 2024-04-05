using GloboTicket.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Contracts.Persistence
{
    public interface IWorkRepository : IAsyncRepository<Work>
    {
        Task<List<Work>> GetWorks();
        Task<List<Work>> GetWorksByFilter(DateTime fromDate, DateTime toDate, Guid cityId, Guid countyId, Guid categoryId, int page, int size);
        Task<int> GetTotalCountOfWorksWithFilter(DateTime fromDate, DateTime toDate, Guid cityId, Guid countyId, Guid categoryId);
    }
}
