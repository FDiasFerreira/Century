using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Century.Business.Models
{
    public class Category : Entity
    {
        //public Guid ProductId { get; set; }

        public bool Active { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
        public Guid Product { get; set; }
    }
}
