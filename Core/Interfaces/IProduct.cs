using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProduct
    {
        public Task<IEnumerable<Product>> GetProducts();
        public Task<Product> GetProduct(int id);
        public Task InserProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(Product product);

        public Task<Tuple<List<Product>,int>> GetProductFilter(TableQuery tableQuery);
        public Task<Product> GetProductById(int id);
        public Task<int> GetProductRowCount();

    }
}
