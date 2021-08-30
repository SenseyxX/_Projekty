using System;

namespace Warehouse.Domain.Abstractions
{
    public abstract class Entity
    {
        protected Entity(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; } // ToDo : Czy powinnismy zmieniać id
    }
}
