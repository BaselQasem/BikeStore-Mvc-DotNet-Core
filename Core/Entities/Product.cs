using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public  class Product : BaseEntity
    {
        public int brand_id;

        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
            Stocks = new HashSet<Stock>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public short ModelYear { get; set; }
        public decimal ListPrice { get; set; }

        public virtual Brand Brand { get; set; } 
        public virtual Category Category { get; set; } 
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
