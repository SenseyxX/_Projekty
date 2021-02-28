using Mag.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Repositories
{
        public class CategoryRepository : ICategoryRepository
        {
                private readonly MagContext _magContext;

                public CategoryRepository(MagContext magContext)
                {
                        _magContext = magContext;
                }

                public async Task<Category> AddCategoryAsync(Category category)
                {
                        var result = await _magContext.categories.AddAsync(category);
                        await _magContext.SaveChangesAsync();
                        return result.Entity; // Dlaczego entity?
                }

                public async Task<Category> DelateCategoryAsync(int categoryId)
                {
                        var result = await _magContext.categories.FirstOrDefaultAsync(m => m.Id == categoryId);
                        if (result!=null)
                        {
                                _magContext.categories.Remove(result);
                                await _magContext.SaveChangesAsync();
                                return result;
                        }
                        return null;
                }

                public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
                {
                        var result = await _magContext.categories.ToListAsync();
                        return result;
                }

                public async Task<Category> GetCategoryAsync(int categoryId)
                {
                        var result = await _magContext.categories
                                .FirstOrDefaultAsync(m => m.Id == categoryId);
                        return result;
                }

                public async Task<Category> UpdateCategoryAsync(Category category)
                {
                        var result = await _magContext.categories
                                .FirstOrDefaultAsync(m => m.Id == category.Id);
                        if (result!=null)
                        {
                                result.Id = category.Id; // Czy dodawać w repo id przy update data?        
                                result.CategoryName = category.CategoryName;
                                result.Description = category.Description;

                                await _magContext.SaveChangesAsync();
                                return result;
                        }
                        return null;
                }
        }
}
