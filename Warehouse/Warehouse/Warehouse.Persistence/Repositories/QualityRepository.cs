using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Persistence.Context;
using Warehouse.Persistence.Entities.Quality;

namespace Warehouse.Persistence.Repositories
{
    class QualityRepository : Repository<Quality>,IQualityRepository
    {
        public QualityRepository(WarehouseContext warehouseContext)
         :base(warehouseContext)
        {
        }

        
    }
}
