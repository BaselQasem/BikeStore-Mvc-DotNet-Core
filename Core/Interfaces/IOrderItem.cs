using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IOrderItem
    {

        public Task<IEnumerable<OrderItem>> GetOrderItems();
        public Task<ICollection<OrderItem>> getOrderItemById(int id);
        public Task<List<OrderItem>> GetOrderItemByOrderId(int orderId);

        public Task<OrderItem> GetOrderItem(int id);
        public Task InserOrderItem(OrderItem orderItem);
        public void UpdateOrderItem(OrderItem orderItem);
        public void DeleteOrderItem(OrderItem orderItem);
        public Task AddRange(IEnumerable<OrderItem> list);
        public void RemoveRange(IEnumerable<OrderItem> list);



    }
}
