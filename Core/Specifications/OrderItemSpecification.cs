using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class OrderItemSpecification:BaseSpecifcation<OrderItem>
    {
    public    OrderItemSpecification(int id) : base()
        {
            AddWhere(i => i.OrderId == id);
            AddInclude(i => i.Product);
        }
    }
}
