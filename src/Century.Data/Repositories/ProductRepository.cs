using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Century.Business.Interfaces;
using Century.Business.Models;
using Century.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Century.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(CenturyDbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetProductsAndSuppliers()
        {
            return await Century.Products.AsNoTracking().Include(s => s.Supplier)
                .OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsBySupplier(Guid supplierid)
        {
            return await Buscar(p => p.SupplierId == supplierid); 
        }

        public async Task<Product> GetProductSupplier(Guid id)
        {
            return await Century.Products.AsNoTracking().Include(s => s.Supplier)
                 .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
