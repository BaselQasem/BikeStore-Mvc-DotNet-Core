using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BikeStore.Models
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            OrderItems = new HashSet<OrderItemViewModel>();
        }

        public int OrderId { get; set; }
       
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select Cusomer")]
        public int? CustomerId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select Status")]
        public byte OrderStatus { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select Store")]
        public int StoreId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select Staff")]
        public int StaffId { get; set; }

       
        public virtual CustomerViewModel? Customer { get; set; }
        
        public virtual StaffViewModel? Staff { get; set; } = null!;
       
        public virtual StoreViewModel? Store { get; set; } = null!;
        [BindProperty]
        public virtual ICollection<OrderItemViewModel> OrderItems { get; set; }
    }
}
