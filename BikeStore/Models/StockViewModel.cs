using System.ComponentModel.DataAnnotations;

namespace BikeStore.Models
{
    public class StockViewModel
    {
        [Required]
        public int StoreId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int? Quantity { get; set; }

        public virtual ProductViewModel? Product { get; set; } = null!;
        public virtual StoreViewModel? Store { get; set; } = null!;
    }
}
