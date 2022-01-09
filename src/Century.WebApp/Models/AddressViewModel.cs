using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Century.WebApp.Models
{
    public class AddressViewModel
    {
        [Key]
        public Guid Id { get; set; }     

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [StringLength(9, ErrorMessage = "The field {0} must have 9 characters")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [StringLength(200, ErrorMessage = "The field {0} must have between {2} and {1} characters",
           MinimumLength = 5)]
        public string Street { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [StringLength(10, ErrorMessage = "The field {0} must have between {2} and {1} characters",
           MinimumLength = 1)]
        public string Number { get; set; }

        public string Complement { get; set; }

        public string Reference { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [StringLength(50, ErrorMessage = "The field {0} must have between {2} and {1} characters",
                  MinimumLength = 2)]
        public string Neighborhood { get; set; }


        [Required(ErrorMessage = "The field {0} is mandatory")]
        [StringLength(50, ErrorMessage = "The field {0} must have between {2} and {1} characters",
                  MinimumLength = 2)]
        public string City { get; set; }


        [Required(ErrorMessage = "The field {0} is mandatory")]
        [StringLength(50, ErrorMessage = "The field {0} must have between {2} and {1} characters",
                  MinimumLength = 2)]
        public string State { get; set; }

        [HiddenInput]
        public Guid SupplierId { get; set; }
    }
}
