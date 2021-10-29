using System;

namespace Warehouse.Domain.Abstractions
{
    public abstract class Aggregate : Entity
    {
        protected Aggregate(Guid id)
            : base(id)
        {
        }
    }
}
