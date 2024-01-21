using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Persistence.Repositories
{
    public class WorkRepository : BaseRepository<Work>, IWorkRepository
    {
        public WorkRepository(GloboTicketDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Work>> GetWorks()
        {
            return await _dbContext.Works.ToListAsync();
        }
    }
}
