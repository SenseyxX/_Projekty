using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Persistence.Entities;

namespace Warehouse.Model.Dtos
{
    public sealed class CategoryDto
    {
        private CategoryDto(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; }
        public string Description { get; }
        // ToDo public ICollection<Item> Items { get;}

        public static explicit operator CategoryDto(Category category)
                => new(category.Name, category.Description);
    }
}
