using System;
using System.Collections.Generic;

namespace Warehouse.Persistence.Entities
{
    public sealed class Squad : Entity
    {
        public Squad(Guid id, string name)
            : base(id)
        {
            Name = name;
            Users = new List<User>();
        }
        public string Name { get; private set; }
        public ICollection<User> Users { get; }

        public bool UpdateName(string name)
        {
            if (Name == name || string.IsNullOrEmpty(name))
            {
                return false;
            }

            Name = name;
            return true;
        }
    }
}
