using System.ComponentModel.DataAnnotations;

namespace BikeStore.Models
{
    public class CategoryViewModel
    {

        public CategoryViewModel()
        {
            Products = new HashSet<ProductViewModel>();
        }

        public int CategoryId { get; set; }
        [Required]
        [MaxLength(30)]
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<ProductViewModel> Products { get; set; }
    }
}
