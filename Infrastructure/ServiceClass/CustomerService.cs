using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ServiceClass
{
    public class CustomerService : ICustomer
    {
        IGenericRepository<Customer> _repository;
        public CustomerService(IGenericRepository<Customer> repository)
        {
            _repository = repository;

        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<Tuple<List<Customer>, int>> GetCustomerFilter(TableQuery tableQuery)
        {

            var res = _repository.FindWithSpecificationPattern(new CustomerFilterSpesification(tableQuery));
            return await Pager<Customer>.buildPaging(tableQuery, res);

        }

        public async Task InserCustomer(Customer customer)
        {
            if (customer != null)
            {
                await _repository.AddAsync(customer);
            }
        }

        public void UpdateCustomer(Customer customer)
        {
             _repository.Update(customer);
        }
        public void DeleteCustomer(Customer customer)
        {
            if (customer != null)
            {
                 _repository.Delete(customer);
            }
        }

    }
}
