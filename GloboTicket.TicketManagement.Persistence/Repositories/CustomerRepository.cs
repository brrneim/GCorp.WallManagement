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
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(GloboTicketDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await _dbContext.Customers.ToListAsync();
        }
        
        public async Task<Customer> GetCustomerByEmail(string mail)
        {
            return await _dbContext.Customers.Where(x=>x.Mail == mail).FirstOrDefaultAsync();
        }
        public async Task<List<Customer>> GetCustomersByFilter(Guid cityId, Guid countyId, Guid categoryId, int page, int size)
        {
            List<Guid> customerCategories = null;

            if (categoryId != Guid.Empty)
            {
                customerCategories = await _dbContext.CustomerCategoryTypes.Where(x => x.CategoryTypeId == categoryId).Select(x => x.CustomerId).ToListAsync();
            }

            var abc = await _dbContext.Customers
                .Include(x => x.CustomerRatings)
                .Include(y => y.CustomerComments)
                .Include(z => z.CustomerCategoryTypes)
                .ThenInclude(y => y.CategoryType)
                .Where(x => !x.IsPassive
            && (cityId == Guid.Empty || x.CityId == cityId)
            && (countyId == Guid.Empty || x.CountyId == countyId)
            && (customerCategories == null || customerCategories.Contains(x.Id))
            && (x.Title != null))
           .Skip((page - 1) * size)
           .Take(size)
           .AsNoTracking()
           .ToListAsync();

           //.
           
            return abc.Select(y => new Customer()
            {
                Id = y.Id,
                Username = y.Username,
                Name = y.Name,
                Surname = y.Surname,
                Title = y.Title == null ? "": y.Title.Substring(0,200) + "...",
                Rating = y.CustomerRatings.Count() > 0 ? y.CustomerRatings.Average(x => x.Value) : decimal.Zero,
                CommentCount = y.CustomerComments.Count(),
                CategoryTypeNames = y.CustomerCategoryTypes.Count() > 0 ? y.CustomerCategoryTypes.Select(x => new SimleCategoryType() { Name = x.CategoryType.Name }).ToList() : new List<SimleCategoryType>() ,

            }).ToList();
        }

        public async Task<int> GetTotalCountOfCustomersWithFilter(Guid cityId, Guid countyId, Guid categoryId)
        {
            List<Guid> customerCategories = null;

            if (categoryId != Guid.Empty)
            {
                customerCategories = await _dbContext.CustomerCategoryTypes.Where(x => x.CategoryTypeId == categoryId).Select(x => x.CustomerId).ToListAsync();

            }

            return await _dbContext.Customers.CountAsync(x => !x.IsPassive
            && (cityId == Guid.Empty || x.CityId == cityId)
            && (countyId == Guid.Empty || x.CountyId == countyId)
            && (customerCategories == null || customerCategories.Contains(x.Id)));
        }

       
    }
}
