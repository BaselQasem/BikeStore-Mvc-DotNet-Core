using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces

{
    public interface IBrand
    {
        public Task<IEnumerable<Brand>> GetBrands();
        public Task<Brand> GetBrand(int id);
        public Task InserBrand(Brand brand);
        public void UpdateBrand(Brand brand);
        public void DeleteBrand(Brand brand); 
        public Task<int> getBrandsCount();
    }
}
