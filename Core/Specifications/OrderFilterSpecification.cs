using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class OrderFilterSpecification :BaseSpecifcation<Order>
    {

        public OrderFilterSpecification(TableQuery orderFilter) : base()
        {


            AddInclude(f => f.Customer);
            AddInclude(f => f.Staff);
            AddInclude(f => f.Store);
            AddInclude(f => f.OrderItems);



            if (orderFilter.Filter != null)
            {
                AddWhere(f => (f.Customer.FirstName.ToLower() + " " + f.Customer.LastName.ToLower()).Contains(orderFilter.Filter.ToLower()));

            }

            if (orderFilter.Sorting == 1)
            {
                AddOrderByDescending(f => f.OrderDate);
            }
            else
            {
                AddOrderBy(f => f.OrderDate);
            }
        }



       

    }
}
