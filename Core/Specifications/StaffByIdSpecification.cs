using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class StaffByIdSpecification : BaseSpecifcation<Staff>
    {
        public StaffByIdSpecification(int staffId) : base()
        {
            AddWhere(s=>s.StaffId==staffId);
            AddInclude(s => s.Manager);
            AddInclude(s => s.Store);
    
        }
    }
}
