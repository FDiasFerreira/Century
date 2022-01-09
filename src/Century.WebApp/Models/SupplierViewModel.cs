using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Century.WebApp.Models
{
    public class SupplierViewModel
    {
        [Key]
        public Guid Id { get; set; }
       
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [DisplayName("Active?")]
        public bool Active { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [StringLength(200, ErrorMessage = "The field {0} must have between {2} and {1} characters",
          MinimumLength = 2)]
        [DisplayName("Fantasy Name")]
        public string FantasyName { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [StringLength(200, ErrorMessage = "The field {0} must have between {2} and {1} characters",
          MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [DisplayName("Supplier Type")]
        public int SupplierType { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [StringLength(14, ErrorMessage = "The field {0} must have 14 characters")]
        public string Document { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [DisplayName("Birth/Open Date")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        public AddressViewModel Address { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        public EmailViewModel Email { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        public PhoneViewModel Phone { get; set; }

        public ProductViewModel Product { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
