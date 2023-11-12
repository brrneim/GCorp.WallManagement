using GloboTicket.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Contracts.Persistence
{
    public interface ICategoryTypeRepository : IAsyncRepository<CategoryType>
    {
        Task<List<CategoryType>> GetCategoriesWithEvents();
    }

}
