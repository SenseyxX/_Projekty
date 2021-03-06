﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Persistence.Entities.Abstractions;

namespace Warehouse.Persistence.Repositories
{
    public interface IRepository<TAggregate>
        where TAggregate : Aggregate
    {
        Task<TAggregate> GetAsync(Guid id, CancellationToken cancellationToken);
        Task<ICollection<TAggregate>> GetRangeAsync(CancellationToken cancellationToken);
        Task CreateAsync(TAggregate entity, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task SaveAsync(CancellationToken cancellationToken);
        void Update(TAggregate entity);
    }
}
