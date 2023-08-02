using System.ComponentModel.DataAnnotations;

namespace BikeStore.Models
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            OrderItems = new HashSet<OrderItemViewModel>();
            Stocks = new HashSet<StockViewModel>();
        }

        public int ProductId { get; set; }
        [Required]
        [MaxLength(300)]
        public string ProductName { get; set; } = null!;
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select Brand")]
        public int BrandId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select Category")]
        public int CategoryId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Enter Valid Year")]
        public short ModelYear { get; set; }
        [Required]
        public decimal ListPrice { get; set; }
        public virtual BrandViewModel? Brand { get; set; } = null!;
        public virtual CategoryViewModel? Category { get; set; } = null!;
        public virtual ICollection<OrderItemViewModel> OrderItems { get; set; }
        public virtual ICollection<StockViewModel> Stocks { get; set; }
    }
}
