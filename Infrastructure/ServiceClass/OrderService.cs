using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using Core.Specifications;

namespace Infrastructure.ServiceClass
{
    public class OrderService : IOrder
    {
        IGenericRepository<Order> _repository;
        public OrderService(IGenericRepository<Order> repository)
        {
            _repository = repository;

        }
        public void DeleteOrder(Order order)
        {
            if (order != null)
            {
                 _repository.Delete(order);
            }
        }

        public async Task<Order> GetOrder(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _repository.GetAllAsync();
        }

        public async Task InserOrder(Order order)
        {
            if (order != null)
            {
                await _repository.AddAsync(order);
            }
        }

        public void UpdateOrder(Order order)
        {
             _repository.Update(order);
        }

        public async Task<Tuple<List<Order>,int>> getOrderFiltered(TableQuery tableQuery)
        {
            var res = _repository.FindWithSpecificationPattern(new OrderFilterSpecification(tableQuery));
            return   await Pager<Order>.buildPaging(tableQuery, res);
        }

        public async Task<Order> getOrderByID(int id)
        {
            var specification = new OrderByIdSpecification(id);
            var ordersGroup = await _repository.FindWithSpecificationPattern(specification).SingleOrDefaultAsync();
            return ordersGroup;
        }
    }
}
