﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Contracts.Commands;
using Warehouse.Model.Dtos;
using Warehouse.Persistence.Factories;
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

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync(CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.GetRangeAsync(cancellationToken);
            return result.Select(category=>(CategoryDto) category);
        }

        public async Task<FullCategoryDto> GetCategoryAsync(Guid id, CancellationToken cancellationToken)
            => (FullCategoryDto) await _categoryRepository.GetAsync(id, cancellationToken);

        public async Task AddCategoryAsync(
            AddCategoryCommand addCategoryCommand,
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
