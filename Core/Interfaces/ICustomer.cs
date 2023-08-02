using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICustomer
    {
        public Task<IEnumerable<Customer>> GetCustomers();
        public Task<Customer> GetCustomer(int id);
        public Task InserCustomer(Customer customer);
        public void UpdateCustomer(Customer customer);
        public void DeleteCustomer(Customer customer);
        public Task<Tuple<List<Customer>, int>> GetCustomerFilter(TableQuery tableQuery);

        
    }
}
