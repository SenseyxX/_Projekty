using System;

namespace Warehouse.Persistence.Entities.Abstractions
{
    public abstract class Aggregate : Entity
    {
        protected Aggregate(Guid id)
            : base(id)
        {
        }
    }
}
