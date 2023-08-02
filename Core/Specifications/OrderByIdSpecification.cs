using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class OrderByIdSpecification:BaseSpecifcation<Order>
    {
        public OrderByIdSpecification(int id) : base()
        {
            AddWhere(o => o.OrderId == id);
            AddInclude(f => f.Customer);
            AddInclude(f => f.Staff);
            AddInclude(f => f.Store);
            AddInclude(f => f.OrderItems);
        }
    }
}
