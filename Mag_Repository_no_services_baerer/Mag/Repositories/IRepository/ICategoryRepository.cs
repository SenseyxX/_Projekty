using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mag.Entities;

namespace Mag.Repositories
{
        public interface ICategoryRepository
        {
                Task<IEnumerable<Category>> GetAllCategoriesAsync();
                Task<Category> GetCategoryAsync(int categoryId);
                Task<Category> AddCategoryAsync(Category category);
                Task<Category> UpdateCategoryAsync(Category category);
                Task<Category> DelateCategoryAsync(int categoryId);
        }
}
