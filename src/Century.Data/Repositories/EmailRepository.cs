using System;
using System.Threading.Tasks;
using Century.Business.Interfaces;
using Century.Business.Models;
using Century.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Century.Data.Repositories
{
    public class EmailRepository : Repository<Email>, IEmailRepository
    {
        public EmailRepository(CenturyDbContext context) : base(context) { }

        public async Task<Email> GetEmailSupplier(Guid supplierId)
        {
            return await Century.Email.AsNoTracking()
                .FirstOrDefaultAsync(s => s.SupplierId == supplierId);
        }
    }
}
