
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Core.Specifications;

namespace Infrastructure.ServiceClass
{
    public class BrandService : IBrand
    {
        IGenericRepository<Brand> _repository;
        
        public BrandService(IGenericRepository<Brand> repository)
        {
            _repository = repository;
            

        }
        public void DeleteBrand(Brand brand)
        {
            if (brand != null)
            {

                 _repository.Delete(brand);

            }
        }

        public async Task<Brand> GetBrand(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Brand>> GetBrands()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<int> getBrandsCount()
        {
          return await _repository.CountAsync();
        }

        public async Task   InserBrand(Brand brand)
        {
            if (brand != null)
            {
              await   _repository.AddAsync(brand);
            }
        }

        public  void UpdateBrand(Brand brand)
        {
             _repository.Update(brand);
        }
    }
}
