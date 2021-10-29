using System;
using System.Collections.Generic;
using Warehouse.Domain.Abstractions;
using Warehouse.Domain.Category.Enumeration;

namespace Warehouse.Domain.Squad.Entities
{
    public sealed class Squad : Aggregate
    {
        public Squad(
            Guid id,
            string name,
            CategoryState categoryState)
            : base(id)
        {
            Name = name;
            CategoryState = categoryState;
            Users = new List<User.Entities.User>();
        }

        public string Name { get; private set; }
        public CategoryState CategoryState { get;private set; }
        public ICollection<User.Entities.User> Users { get; }

        public bool UpdateName(string name)
        {
            if (Name == name || string.IsNullOrEmpty(name))
            {
                return false;
            }

            Name = name;
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
