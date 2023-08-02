using Core.Entities;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IOrder
    {

        public Task<IEnumerable<Order>> GetOrders();
        public Task<Tuple<List<Order>, int>> getOrderFiltered(TableQuery tableQuery);

        public Task<Order> GetOrder(int id);
        public Task<Order> getOrderByID(int id);
        public Task InserOrder(Order order);
        public void UpdateOrder(Order order);
        public void DeleteOrder(Order order);
    }       
}
