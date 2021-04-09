using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Dtos;
using Warehouse.Persistence.Entities;
using Warehouse.Persistence.Repositories;

namespace Warehouse.Model.Services
{
    public sealed class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryDto> AddCategoryAsync(Category category)
        {
            var result = await _categoryRepository.AddCategoryAsync(category);
            return (CategoryDto)result;
        }

        public async Task DeleteCategoryAsync(Guid Id)
        {
            await _categoryRepository.DelateCategoryAsync(Id);
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync(CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.GetAllCategoriesAsync(cancellationToken);
            return result.Select(category=>(CategoryDto)category);
        }

        public async Task<CategoryDto> GetCategoryAsync(Guid Id)
        {
            var result = await _categoryRepository.GetCategoryAsync(Id);
            return (CategoryDto)result;
        }

        public Task UpdateCategoryAsync(Category category, Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
