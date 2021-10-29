using System;
using System.Collections.Generic;
using Warehouse.Domain.Abstractions;
using Warehouse.Domain.Category.Enumeration;

namespace Warehouse.Domain.Category.Entities
{
    public sealed class Category : Aggregate
    {
        public Category(Guid id,
            string name,
            string description,
            CategoryState categoryState)
            : base(id)
        {
            Name = name;
            Description = description;
            CategoryState = categoryState;
            Items = new List<Item.Entities.Item>();
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public CategoryState CategoryState { get;private set; }
        public ICollection<Item.Entities.Item> Items { get; }

        public bool UpdateName(string name)
        {
            if (Name == name || string.IsNullOrEmpty(name))
            {
                return false;
            }

            Name = name;
            return true;
        }

        public bool UpdateDescription(string description)
        {
            if (Description == description || string.IsNullOrEmpty(description))
            {
                return false;
            }

            Description = description;
            return true;
        }

        public bool Activate()
        {
            if (CategoryState == CategoryState.Active)
            {
                return false;
            }

            CategoryState = CategoryState.Active;
            return true;
        }

        public bool Delete()
        {
            if (CategoryState == CategoryState.Deleted)
            {
                return false;
            }

            CategoryState = CategoryState.Deleted;
            return true;
        }
    }
}
