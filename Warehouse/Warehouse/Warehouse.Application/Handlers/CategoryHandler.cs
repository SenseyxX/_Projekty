using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Application.Contracts.Commands.Category;
using Warehouse.Application.Dtos.Category;
using Warehouse.Domain.Category;
using Warehouse.Domain.Category.Factories;

namespace Warehouse.Application.Handlers
{
    public sealed class CategoryHandler
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync(CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.GetRangeAsync(cancellationToken);
            return result.Select(category=>(CategoryDto) category);
        }

        public async Task<FullCategoryDto> GetCategoryAsync(Guid id, CancellationToken cancellationToken)
            => (FullCategoryDto) await _categoryRepository.GetAsync(id, cancellationToken);

        public async Task AddCategoryAsync(
            CreateCategoryCommand addCategoryCommand,
            CancellationToken cancellationToken)
        {
            var category = CategoryFactory.Create(addCategoryCommand.Name, addCategoryCommand.Description);
            await _categoryRepository.CreateAsync(category, cancellationToken);
            await _categoryRepository.SaveAsync(cancellationToken);
        }

        public async Task UpdateCategoryAsync(
            UpdateCategoryCommand updateCategoryCommand,
            CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetAsync(updateCategoryCommand.CategoryId, cancellationToken);
            var isUpdated = category.UpdateName(updateCategoryCommand.Name);
            isUpdated = category.UpdateDescription(updateCategoryCommand.Description) || isUpdated;

            if (isUpdated)
            {
                _categoryRepository.Update(category);
                await _categoryRepository.SaveAsync(cancellationToken);
            }
        }

        public async Task DeleteCategoryAsync(Guid id, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetAsync(id, cancellationToken);
            var updated = category.Delete();

            if (updated)
            {
                _categoryRepository.Update(category);
                await _categoryRepository.SaveAsync(cancellationToken);
            }
        }
    }
}
