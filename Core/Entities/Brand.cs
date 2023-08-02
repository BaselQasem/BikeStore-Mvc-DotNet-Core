using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public  class Brand : BaseEntity
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        
        public int BrandId { get; set; }
        
        public string BrandName { get; set; } = null!;

        public virtual ICollection<Product> ?Products { get; set; }
    }
}
