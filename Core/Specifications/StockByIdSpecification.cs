using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class StockByIdSpecification : BaseSpecifcation<Stock>
    {
        public StockByIdSpecification(int StoreId ,int prodcutId) : base()
        {
            AddWhere(s => s.StoreId == StoreId && s.ProductId == prodcutId);
            AddInclude(s => s.Store);
            AddInclude(s => s.Product);
    
        }
    }
}
