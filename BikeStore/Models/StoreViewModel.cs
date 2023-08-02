using System.ComponentModel.DataAnnotations;

namespace BikeStore.Models
{
    public class StoreViewModel
    {
        public StoreViewModel()
        {
            Orders = new HashSet<OrderViewModel>();
            Stocks = new HashSet<StockViewModel>();
            staff = new HashSet<StaffViewModel>();
        }

        public int StoreId { get; set; }


        [Required(ErrorMessage = "Store Name Required")]
        [MaxLength(80)]
        public string StoreName { get; set; } = null!;

        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Phone")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Email Required")]
        public string? Email { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Street Required")]
        public string? Street { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "City Required")]
        public string? City { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "State Required")]
        public string? State { get; set; }

        [Required(ErrorMessage = "ZipCode Required")]
        public string? ZipCode { get; set; }

        public virtual ICollection<OrderViewModel> Orders { get; set; }
        public virtual ICollection<StockViewModel> Stocks { get; set; }
        public virtual ICollection<StaffViewModel> staff { get; set; }
    }
}
