using System;
using Warehouse.Domain.Category.Entities;

namespace Warehouse.Application.Dtos
{
    public class CategoryDto
    {
        protected CategoryDto(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }

        public static explicit operator CategoryDto(Category category)
            => new(category.Id,
                   category.Name, 
                   category.Description);
    }
}
