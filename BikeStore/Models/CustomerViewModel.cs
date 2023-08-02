using System.ComponentModel.DataAnnotations;

namespace BikeStore.Models
{
    public class CustomerViewModel
    {
        public CustomerViewModel()
        {
            Orders = new HashSet<OrderViewModel>();
        }
        public int CustomerId { get; set; }
        [Required(ErrorMessage ="First Name Required")]
        [MaxLength(80)]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Last Name Required")]
        [MaxLength(80)]
        public string LastName { get; set; } = null!;

        [DataType(DataType.PhoneNumber,ErrorMessage ="Invalid Phone")]
        public string? Phone { get; set; }

        [Required(ErrorMessage ="Email Required")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Inncorrect Email")]
        public string Email { get; set; } = null!;
       
        [MaxLength(100)]
        [Required(ErrorMessage ="Street Required")]
        public string? Street { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "City Required")]
        public string? City { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "State Required")]
        public string? State { get; set; }

        [Required(ErrorMessage = "ZipCode Required")]
        public string? ZipCode { get; set; }

        public string? FullName { get { return FirstName + " " + LastName; } }

        public virtual ICollection<OrderViewModel> Orders { get; set; }
    }
}
