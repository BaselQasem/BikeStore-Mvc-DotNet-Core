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
    public class ProductFilterSpesification :BaseSpecifcation<Product>
    {
        public ProductFilterSpesification(TableQuery productFilter) : base()
        {

            AddInclude(c => c.Category);
            AddInclude(b => b.Brand);

            if (productFilter.Filter != null) { 
                AddWhere(p=>p.ProductName.Contains(productFilter.Filter));}
            if (productFilter.otherFilters != 0)
            {

                AddWhere(p => p.CategoryId == productFilter.otherFilters);
            }
            if (productFilter.Sorting == 1)
            {
                AddOrderByDescending(f => f.ProductName);
            }
            else
            {
                AddOrderBy(f => f.ProductName);
            }
        }
     
    }
}
