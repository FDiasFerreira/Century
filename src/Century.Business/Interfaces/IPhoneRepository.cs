using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Century.Business.Models;

namespace Century.Business.Interfaces
{
    public interface IPhoneRepository : IRepository<Phone>
    {
        Task<Phone> GetPhoneSupplier(Guid supplierId);
    }
}
