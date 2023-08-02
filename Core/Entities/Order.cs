using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public  class Order : BaseEntity
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public byte OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int StoreId { get; set; }
        public int StaffId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Staff Staff { get; set; } = null!;
        public virtual Store Store { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
