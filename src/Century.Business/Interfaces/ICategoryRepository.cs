using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Century.Business.Models;

namespace Century.Business.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetCategory(Guid categoryId);
        Task<IEnumerable<Category>> GetCategories();
        Task<IEnumerable<Category>> GetProductsByCategory(Guid categoryId);
    }
}
