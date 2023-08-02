using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class StocksByProductIdSpesification :BaseSpecifcation<Stock>
    {
     public StocksByProductIdSpesification(int id):base()
        {
            AddWhere(i => i.ProductId == id);
        }
    }
}
