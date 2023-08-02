using System.ComponentModel.DataAnnotations;

namespace BikeStore.Models
{
    public class OrderItemViewModel
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        [Range(1,100)]
        public int Quantity { get; set; }
        [Required]
        public decimal ListPrice { get; set; }
       
        public decimal Discount { get; set; }

        public virtual OrderViewModel? Order { get; set; } = null!;
        public virtual ProductViewModel? Product { get; set; } = null!;
    }
}
