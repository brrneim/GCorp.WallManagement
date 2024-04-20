using GloboTicket.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Contracts.Persistence
{
    public interface ICustomerRepository : IAsyncRepository<Customer>
    {
        Task<List<Customer>> GetCustomers();
        Task<List<Customer>> GetCustomersByFilter(Guid cityId, Guid countyId, Guid categoryId, int page, int size);
        Task<int> GetTotalCountOfCustomersWithFilter(Guid cityId, Guid countyId, Guid categoryId);
    }

}
