using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Century.WebApp.Models
{
    public class EmailViewModel
    {
        [Key]
        public Guid Id { get; set; }


        [Required(ErrorMessage = "The field {0} is mandatory")]
        [StringLength(100, ErrorMessage = "The field {0} must have between {2} and {1} characters",
           MinimumLength = 5)]
        [DisplayName("E-mail")]
        public string EmailAddress { get; set; }

        [HiddenInput]
        public Guid SupplierId { get; set; }
    }
}
