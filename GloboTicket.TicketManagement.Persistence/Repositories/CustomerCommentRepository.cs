using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.TicketManagement.Persistence.Repositories
{

    public class CustomerCommentRepository : BaseRepository<CustomerComment>, ICustomerCommentRepository
    {
        public CustomerCommentRepository(GloboTicketDbContext dbContext) : base(dbContext)
        {
        }

        public Task<IQueryable<CustomerComment>> GetCommentsByCustomerId(Guid customerId)
        {
            var allCustomerComments = _dbContext.CustomerComments.Where(e => e.CommentCustomerId.Equals(customerId));

            return Task.FromResult(allCustomerComments); 
        }
    }
}
