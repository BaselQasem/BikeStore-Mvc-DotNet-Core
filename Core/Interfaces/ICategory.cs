using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICategory
    {
        public Task<IEnumerable<Category>> GetCategories();
        public Task<Category> GetCategory(int id);
        public Task InserCategory(Category category);
        public void UpdateCategory(Category category);
        public void DeleteCategory(Category category);
    }
}
