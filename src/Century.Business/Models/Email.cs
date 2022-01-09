using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Century.Business.Models
{
    public class Email : Entity
    {
        public Guid SupplierId { get; set; }

        public string EmailAddress { get; set; }

        public Supplier Supplier { get; set; }
    }
}
