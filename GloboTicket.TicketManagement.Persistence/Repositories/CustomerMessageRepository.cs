using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Persistence.Repositories
{

    public class CustomerMessageRepository : BaseRepository<CustomerMessage>, ICustomerMessageRepository
    {
        public CustomerMessageRepository(GloboTicketDbContext dbContext) : base(dbContext)
        {
        }

        public Task<IQueryable<CustomerMessage>> GetMessagesByCustomerId(Guid customerId)
        {
            var allCustomerComments = _dbContext.CustomerMessages.Where(e => e.CustomerReceiverId.Equals(customerId));

            return Task.FromResult(allCustomerComments);
        }
    }


}
