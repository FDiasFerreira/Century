using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Century.WebApp.Models
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [HiddenInput]
        [DisplayName("Suppliers")]
        public Guid SupplierId { get; set; }


        [Required(ErrorMessage = "The field {0} is mandatory")]
        [StringLength(200, ErrorMessage = "The field {0} must have between {2} and {1} characters",
            MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [StringLength(13, ErrorMessage = "The field {0} must have 13 characters")]
        public string BarCode { get; set; }


        [Required(ErrorMessage = "The field {0} is mandatory")]
        [DisplayName("Quantity in Stock")]
        public int QuantityStock { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [DisplayName("Active?")]
        public bool Active { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [DisplayName("Sales Price")]
        public decimal PriceSales { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [DisplayName("Purchase Price")]
        public decimal PricePurchase { get; set; }

        [StringLength(100, ErrorMessage = "The field {0} must have between {2} and {1} characters",
            MinimumLength = 2)]
        public string ImagePath { get; set; }

        [DisplayName("Image")]
        public IFormFile ImageUpload { get; set; }

        public SupplierViewModel Supplier { get; set; }

        public CategoryViewModel Category { get; set; }

        public IEnumerable<SupplierViewModel> Suppliers { get; set; }






    }
}
