using System;
using System.Threading.Tasks;
using Century.Business.Interfaces;
using Century.Business.Models;
using Century.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Century.Data.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(CenturyDbContext context) : base(context) { }

        public async Task<Address> GetAddressSupplier(Guid supplierId)
        {
            return await Century.Address.AsNoTracking()
                .FirstOrDefaultAsync(s => s.SupplierId == supplierId);
        }
    }
}
