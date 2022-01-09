using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Century.Business.Models
{
    public class Phone : Entity
    {
        public Guid SupplierId { get; set; }

        public string Ddd { get; set; }
        public string Number { get; set; }

        public Supplier Supplier { get; set; }
    }
}
