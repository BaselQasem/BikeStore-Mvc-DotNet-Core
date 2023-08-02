using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductByIdSpecification : BaseSpecifcation<Product>
    {
        public ProductByIdSpecification(int id) : base()
        {
            AddWhere(o => o.ProductId == id);
            AddInclude(p=>p.Brand);
            AddInclude(p=>p.Category);
            
        }
    }
}
