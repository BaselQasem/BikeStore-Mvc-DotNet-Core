using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ServiceClass
{
    public class CategoryService :ICategory
    {
        IGenericRepository<Category> _repository;
        public CategoryService(IGenericRepository<Category> repository)
        {
            _repository = repository;

        }
        public void DeleteCategory(Category category)
        {
            if (category != null)
            {

                 _repository.Delete(category);

            }
        }

        public async Task<Category> GetCategory(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _repository.GetAllAsync();
        }

        public async Task InserCategory(Category category)
        {
            if (category != null)
            {
                await _repository.AddAsync(category);
            }
        }

        public  void UpdateCategory(Category category)
        {
             _repository.Update(category);
        }

      
    }
}
