using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BikeStore.Models
{
    public class BrandViewModel
    {
        //public BrandViewModel()
        //{
        //    Products = new HashSet<ProductViewModel>();
        //}

        public int BrandId { get; set; }
        [Required]
        [MaxLength(30)]
        public string BrandName { get; set; } = null!;

    }
}
