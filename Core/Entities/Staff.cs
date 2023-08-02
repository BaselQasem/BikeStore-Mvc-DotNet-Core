using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Staff : BaseEntity
    {
        public Staff()
        {
            InverseManager = new HashSet<Staff>();
            Orders = new HashSet<Order>();
        }

        public int StaffId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public byte Active { get; set; }
        public int StoreId { get; set; }
        public int? ManagerId { get; set; }

        public virtual Staff? Manager { get; set; }
        public virtual Store Store { get; set; } = null!;
        public virtual ICollection<Staff> InverseManager { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
