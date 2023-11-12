using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Persistence.Repositories
{
    public class StateRepository : BaseRepository<State>, IStateRepository
    {
        public StateRepository(GloboTicketDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<State>> GetStatesWithEvents()
        {
            var allCategories = await _dbContext.States.ToListAsync();
            return allCategories;
        }
    }
}
