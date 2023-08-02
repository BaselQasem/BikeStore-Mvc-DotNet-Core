using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class StoreFilterSpecification : BaseSpecifcation<Store>
    {
        public StoreFilterSpecification(TableQuery storeFilter) : base()
        {

            AddInclude(c => c.Stocks);
            AddInclude(b => b.staff);

            if (storeFilter.Filter != null)
            {
                AddWhere(p => p.StoreName.Contains(storeFilter.Filter));
            }

            if (storeFilter.Sorting == 1)
            {
                AddOrderByDescending(f => f.StoreName);
            }
            else
            {
                AddOrderBy(f => f.StoreName);
            }
        }
    }
}
