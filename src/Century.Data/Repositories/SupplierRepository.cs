using System;
using System.Threading.Tasks;
using Century.Business.Interfaces;
using Century.Business.Models;
using Century.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Century.Data.Repositories
{
   public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(CenturyDbContext context) : base(context) { }

        public async Task<Supplier> GetSupplierAddressPhoneEmail(Guid id)
        {
            return await Century.Suppliers.AsNoTracking()
                .Include(s => s.Address)
                .Include(s => s.Phone)
                .Include(s => s.Email)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Supplier> GetSupplierProductsAddressPhoneEmail(Guid id)
        {
            return await Century.Suppliers.AsNoTracking()
               .Include(s => s.Address)
               .Include(s => s.Phone)
               .Include(s => s.Email)
               .Include(s => s.Products)
               .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
    
    
}
