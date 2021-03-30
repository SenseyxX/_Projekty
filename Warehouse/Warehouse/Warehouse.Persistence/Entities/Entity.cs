using System;

namespace Warehouse.Persistence.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
    }
}
