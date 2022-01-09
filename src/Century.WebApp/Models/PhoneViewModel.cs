using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Century.WebApp.Models
{
    public class PhoneViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [StringLength(2, ErrorMessage = "O campo {0} precisa ter 2 caracteres")]
        public string Ddd { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [StringLength(9, ErrorMessage = "The field {0}must have between {2} e {1} characters",
          MinimumLength = 8)]
        [DisplayName("Phone Number")]
        public string Number { get; set; }

        [HiddenInput]
        public Guid SupplierId { get; set; }
    }
}
