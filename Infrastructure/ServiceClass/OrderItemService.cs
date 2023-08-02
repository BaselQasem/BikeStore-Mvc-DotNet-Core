using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ServiceClass
{
    public class OrderItemService :IOrderItem
    {
        IGenericRepository<OrderItem> _repository;
        public OrderItemService(IGenericRepository<OrderItem> repository)
        {
            _repository = repository;
        }
        public void DeleteOrderItem(OrderItem orderItem)
        {
            if (orderItem != null)
            {

                 _repository.Delete(orderItem);

            }
        }
        public async Task<OrderItem> GetOrderItem(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItems()
        {
            return await _repository.GetAllAsync();
        }
        public async Task InserOrderItem(OrderItem orderItem)
        {
            if (orderItem != null)
            {
                await _repository.AddAsync(orderItem);
            }
        }
        public async Task AddRange(IEnumerable<OrderItem> list)
        {
            await _repository.AddRangeAsync(list);
        }
        public void UpdateOrderItem(OrderItem orderItem)
        {
             _repository.Update(orderItem);
        }

        public async Task<ICollection<OrderItem>> getOrderItemById(int id)
        {
            var specification = new OrderItemSpecification(id);
            return  await  _repository.FindWithSpecificationPattern(specification).ToListAsync();
        }

        public void RemoveRange(IEnumerable<OrderItem> list)
        {
            _repository.DeleteRange(list);
        }

        public async Task<List<OrderItem>> GetOrderItemByOrderId(int orderId)
        {
            var specification = new BaseSpecifcation<OrderItem>(i => i.OrderId == orderId);
            return await  _repository.FindWithSpecificationPattern(specification).ToListAsync();
        }
    }
}
