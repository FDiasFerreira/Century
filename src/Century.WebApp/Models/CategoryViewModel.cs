using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Century.WebApp.Models
{
    public class CategoryViewModel
    {
        [Key]
        public Guid Id { get; set; }


        [Required(ErrorMessage = "The field {0} is mandatory")]       
        public bool Active { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [StringLength(100, ErrorMessage = "The field {0} must have between {2} and {1} characters",
           MinimumLength = 2)]        
        public string Name { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
