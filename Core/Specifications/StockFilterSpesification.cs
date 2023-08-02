using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class StockFilterSpesification : BaseSpecifcation<Stock>
    {
        public StockFilterSpesification(TableQuery tableQuery) : base()
        {
            if (tableQuery.Filter != null)
            {
                AddWhere(f => f.Product.ProductName.Contains(tableQuery.Filter));
            }
            AddInclude(s => s.Product);
            AddInclude(s => s.Store);
            if (tableQuery.Sorting == 1)
            {
                AddOrderByDescending(s => s.Store.StoreName);
            }
            else
            {
                AddOrderBy(s => s.Store.StoreName);
            }

        }
    }
}
