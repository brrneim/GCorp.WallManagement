using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Persistence.Repositories
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(GloboTicketDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<City>> GetStatesWithEvents()
        {
            var allCategories = await _dbContext.Cities.ToListAsync();
            return allCategories;
        }
    }
}
