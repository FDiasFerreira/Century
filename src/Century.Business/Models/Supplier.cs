using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Century.Business.Models
{
    public class Supplier : Entity
    {
        public bool Active { get; set; }
        public string FantasyName { get; set; }
        public string Name { get; set; }
        public SupplierType SupplierType { get; set; }
        public string Document { get; set; }
        public DateTime BirthDate { get; set; }

        public Address Address { get; set; }
        
        public Email Email { get; set; }
        
        public Phone Phone { get; set; }
        
        public IEnumerable<Product> Products { get; set; }
        
    }
}
