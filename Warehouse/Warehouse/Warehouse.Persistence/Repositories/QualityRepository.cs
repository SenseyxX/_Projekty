using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Persistence.Context;
using Warehouse.Persistence.Entities.Quality;

namespace Warehouse.Persistence.Repositories
{
    class QualityRepository : IQualityRepository
    {
        private readonly WarehouseContext _warehouseContext;

        public QualityRepository(WarehouseContext warehouseContext)
        {
            _warehouseContext = warehouseContext;
        }

        public async Task<IEnumerable<Quality>> GetAllQualityAsync(CancellationToken cancellationToken)
        {
            return await _warehouseContext.Qualities
                    .ToListAsync(cancellationToken);
        }

        public async Task<Quality> GetQualityAsync(Guid Id)
        {
            return await _warehouseContext.Qualities
                    .FirstOrDefaultAsync(quality => quality.Id == Id);
        }
    }
}
