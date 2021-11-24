using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Abstractions;

namespace Warehouse.Infrastructure.Repositories
{
    public abstract class Repository<TAggregate> : IRepository<TAggregate>
        where TAggregate : Aggregate
    {
        protected DbContext DbContext;

        protected Repository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual async Task<TAggregate> GetAsync(Guid squadId, CancellationToken cancellationToken)
            => await DbContext
                .Set<TAggregate>()
                .FirstOrDefaultAsync(entity => entity.Id == squadId, cancellationToken);

        public virtual async Task<ICollection<TAggregate>> GetRangeAsync(CancellationToken cancellationToken)
            => await DbContext
                .Set<TAggregate>()
                .ToListAsync(cancellationToken);

        public virtual async Task CreateAsync(TAggregate entity, CancellationToken cancellationToken)
            => await DbContext
                .Set<TAggregate>()
                .AddAsync(entity, cancellationToken);

        public virtual async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var entityToRemove = await GetAsync(id, cancellationToken);
            if (entityToRemove is null)
            {
                throw new NullReferenceException();
            }

            DbContext
                .Set<TAggregate>()
                .Remove(entityToRemove);
        }

        public virtual async Task SaveAsync(CancellationToken cancellationToken)
            => await DbContext.SaveChangesAsync(cancellationToken);

        public virtual void Update(TAggregate entity)
        {
            DbContext
                .Set<TAggregate>()
                .Update(entity);
        }
    }
}
