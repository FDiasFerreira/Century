using System;
using System.Threading.Tasks;
using Century.Business.Interfaces;
using Century.Business.Models;
using Century.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Century.Data.Repositories
{
    public class PhoneRepository : Repository<Phone>, IPhoneRepository
    {
        public PhoneRepository(CenturyDbContext context) : base(context) { }

        public async Task<Phone> GetPhoneSupplier(Guid supplierId)
        {
            return await Century.Phones.AsNoTracking()
               .FirstOrDefaultAsync(s => s.SupplierId == supplierId);
        }
    }
}
