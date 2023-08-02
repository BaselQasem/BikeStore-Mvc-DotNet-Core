using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class StaffFilterSpecification :BaseSpecifcation<Staff>
    {
     public StaffFilterSpecification(TableQuery tableQuery) : base()
        {

            AddInclude(s => s.Manager);
            AddInclude(s => s.Store);
            if(tableQuery.Filter != null)
            {
                AddWhere(f => (f.FirstName.ToLower() + " " + f.LastName.ToLower()).Contains(tableQuery.Filter.ToLower()));
            }

            if (tableQuery.Sorting == 1)
            {
                AddOrderByDescending(f => f.FirstName);

            }
            else
            {
                AddOrderBy(f => f.FirstName);
            }

        }

    }
}
