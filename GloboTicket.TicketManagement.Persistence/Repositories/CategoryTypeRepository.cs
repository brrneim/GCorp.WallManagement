using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Persistence.Repositories
{
    public class CategoryTypeRepository : BaseRepository<CategoryType>, ICategoryTypeRepository
    {
        public CategoryTypeRepository(GloboTicketDbContext dbContext) : base(dbContext)
        {
        }


        public async Task<List<CategoryType>> GetCategoriesWithEvents()
        {
            var allCategories = await _dbContext.CategoryTypes.ToListAsync();
            return allCategories;
        }
    }
}
