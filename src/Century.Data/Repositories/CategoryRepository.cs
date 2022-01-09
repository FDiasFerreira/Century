using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Century.Business.Interfaces;
using Century.Business.Models;
using Century.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Century.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(CenturyDbContext context) : base(context) { }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await Century.Categories.AsNoTracking()
                .ToListAsync();
        }

        public async Task<Category> GetCategory(Guid categoryId)
        {
            return await Century.Categories.AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Category>> GetProductsByCategory(Guid categoryId)
        {
            return await Century.Categories.AsNoTracking().Include(p => p.Products)
               .ToListAsync();
        }
    }
}
