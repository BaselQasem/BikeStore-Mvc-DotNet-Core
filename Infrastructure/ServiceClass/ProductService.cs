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
    public class ProductService:IProduct
    {
        IGenericRepository<Product> _repository;
        public ProductService(IGenericRepository<Product> repository)
        {
            _repository = repository;

        }
        public void DeleteProduct(Product product)
        {
            if (product != null)
            {

                 _repository.Delete(product);

            }
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

         public async Task<IEnumerable<Product>> GetProducts()
        {
           
            return await _repository.GetAllAsync();
        }

        public async Task InserProduct(Product product)
        {
            if (product != null)
            {
                await _repository.AddAsync(product);
            }
        }

        public void UpdateProduct(Product product)
        {
             _repository.Update(product);
        }




        public async Task<Tuple<List<Product>,int>> GetProductFilter(TableQuery tableQuery)
        {
            
            var res=    _repository.FindWithSpecificationPattern(new ProductFilterSpesification(tableQuery));
            return  await Pager<Product>.buildPaging(tableQuery, res);

        }
        public async Task<Product> GetProductById(int id)
        {
            var spesification = new ProductByIdSpecification(id);
          return   await _repository.FindWithSpecificationPattern(spesification).SingleOrDefaultAsync();
        }

        public async Task<int> GetProductRowCount()
        {
            return await _repository.CountAsync();
        }
    }
}
