using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Persistence.Entities;

namespace Warehouse.Persistence.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : Entity
    {
        Task<TEntity> GetAsync(Guid id, CancellationToken cancellationToken);
        Task<ICollection<TEntity>> GetRangeAsync(CancellationToken cancellationToken);
        Task CreateAsync(TEntity entity, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task SaveAsync(CancellationToken cancellationToken);
        void Update(TEntity entity);
    }
}
