using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Persistence.Entities.Quality;

namespace Warehouse.Persistence.Repositories
{
    public interface IQualityRepository
    {
        Task<IEnumerable<Quality>> GetAllQualityAsync(CancellationToken cancellationToken);
        Task<Quality> GetQualityAsync(Guid Id);
    }
}
