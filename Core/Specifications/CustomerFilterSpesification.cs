using Core.Entities;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class CustomerFilterSpesification :BaseSpecifcation<Customer>
    {
        public CustomerFilterSpesification(TableQuery CustomerFilter) : base()
        {

            if (CustomerFilter.Filter != null) { 
                AddWhere(f => (f.FirstName.ToLower() + " " + f.LastName.ToLower()).Contains(CustomerFilter.Filter.ToLower()));
            }

            if (CustomerFilter.Sorting == 1)
            {
                AddOrderByDescending(f => f.FirstName);
            }
            else
            {
                AddOrderBy(f => f.LastName);
            }
        }
    
    }
}
