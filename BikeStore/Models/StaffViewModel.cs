using System.ComponentModel.DataAnnotations;

namespace BikeStore.Models
{
    public class StaffViewModel
    {
        public StaffViewModel()
        {
            InverseManager = new HashSet<StaffViewModel>();
            Orders = new HashSet<OrderViewModel>();
        }

        public int StaffId { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = null!;
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        
        public bool Active { get; set; } = false;
        public int StoreId { get; set; }
        public int? ManagerId { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public virtual StaffViewModel? Manager { get; set; }
        public virtual StoreViewModel? Store { get; set; } = null!;
        public virtual ICollection<StaffViewModel> InverseManager { get; set; }
        public virtual ICollection<OrderViewModel> Orders { get; set; }
    }
}
