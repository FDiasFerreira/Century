using System;


namespace Century.Business.Models
{
    public class Product : Entity
    {
        public Guid SupplierId { get; set; }
        public Guid CategoryId { get; set; }       

        public string Name { get; set; }
        public string BarCode { get; set; }
        public int QuantityStock { get; set; }
        public bool Active { get; set; }
        public decimal PriceSales { get; set; }
        public decimal PricePurchase { get; set; }
        public string ImagePath { get; set; }

        public Supplier Supplier { get; set; }
        public Category Category { get; set; }
       

    }
}
