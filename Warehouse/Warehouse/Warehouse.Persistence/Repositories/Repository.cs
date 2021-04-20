using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.Persistence.Entities;

namespace Warehouse.Persistence.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        protected DbContext DbContext;

        protected Repository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual async Task<TEntity> GetAsync(Guid id, CancellationToken cancellationToken)
            => await DbContext
                .Set<TEntity>()
                .FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);

        public virtual async Task<ICollection<TEntity>> GetRangeAsync(CancellationToken cancellationToken)
            => await DbContext
                .Set<TEntity>()
                .ToListAsync(cancellationToken);

        public virtual async Task CreateAsync(TEntity entity, CancellationToken cancellationToken)
            => await DbContext
                .Set<TEntity>()
                .AddAsync(entity, cancellationToken);

        public virtual async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var entityToRemove = await GetAsync(id, cancellationToken);
            if (entityToRemove is null)
            {
                throw new NullReferenceException();
            }

            DbContext
                .Set<TEntity>()
                .Remove(entityToRemove);
        }

        public virtual async Task SaveAsync(CancellationToken cancellationToken)
            => await DbContext.SaveChangesAsync(cancellationToken);

        public virtual void Update(TEntity entity)
        {
            DbContext
                .Set<TEntity>()
                .Update(entity);
        }
    }
}
