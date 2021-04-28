    using System;
using System.Collections.Generic;
    using Warehouse.Persistence.Entities.Abstractions;

    namespace Warehouse.Persistence.Entities
{
    public sealed class Category : Aggregate
    {
        public Category(Guid id, string name, string description)
            : base(id)
        {
            Name = name;
            Description = description;
            Items = new List<Item.Entities.Item>();
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
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
    }
}
