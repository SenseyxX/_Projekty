﻿using System;

namespace Warehouse.Persistence.Entities.Abstractions
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
