using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Persistence.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(GloboTicketDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await _dbContext.Customers.ToListAsync();
        }
    }
}
