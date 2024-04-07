using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        public async Task<List<Work>> GetWorksByFilter(DateTime fromDate, DateTime toDate, Guid cityId, Guid countyId, Guid categoryId, int page, int size)
        {
            List<Guid> workCategoryTypes = null;

            if (categoryId != Guid.Empty)
            {
                workCategoryTypes = await _dbContext.WorkCategoryTypes.Where(x => x.CategoryTypeId == categoryId).Select(x => x.WorkId).ToListAsync();

            }

            return await _dbContext.Works.Where(x => x.IsActive
            && (fromDate == DateTime.MinValue || x.ExpireDate > fromDate)
            && (toDate == DateTime.MinValue || x.ExpireDate <= toDate)
            && (cityId == Guid.Empty || x.CityId == cityId)
            && (countyId == Guid.Empty || x.CountyId == countyId)
            && (workCategoryTypes == null || workCategoryTypes.Contains(x.Id)))
           .Skip((page - 1) * size)
           .Take(size)
           .AsNoTracking()
           .ToListAsync();
        }

        public async Task<int> GetTotalCountOfWorksWithFilter(DateTime fromDate, DateTime toDate, Guid cityId, Guid countyId, Guid categoryId)
        {
            List<Guid> workCategoryTypes = null;

            if (categoryId != Guid.Empty)
            {
                workCategoryTypes = await _dbContext.WorkCategoryTypes.Where(x => x.CategoryTypeId == categoryId).Select(x => x.WorkId).ToListAsync();

            }

            return await _dbContext.Works.CountAsync(x => x.IsActive
            && (fromDate == DateTime.MinValue || x.ExpireDate > fromDate)
            && (toDate == DateTime.MinValue || x.ExpireDate <= toDate)
            && (cityId == Guid.Empty || x.CityId == cityId)
            && (countyId == Guid.Empty || x.CountyId == countyId)
            && (workCategoryTypes == null || workCategoryTypes.Contains(x.Id)));

        }
    }
}
