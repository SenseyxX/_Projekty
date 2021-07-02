using System;
using System.Collections.Generic;
using Warehouse.Persistence.Entities.Abstractions;

namespace Warehouse.Persistence.Entities
{
    public sealed class Squad : Aggregate
    {
        public Squad(Guid id,
            string name,
            State state)
            : base(id)
        {
            Name = name;
            State = state;
            Users = new List<User.Entities.User>();
        }

        public string Name { get; private set; }
        public State State { get;private set; }
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
            if (State == State.Active)
            {
                return false;
            }

            State = State.Active;
            return true;
        }

        public bool Delete()
        {
            if (State == State.Deleted)
            {
                return false;
            }

            State = State.Deleted;
            return true;
        }
    }
}
