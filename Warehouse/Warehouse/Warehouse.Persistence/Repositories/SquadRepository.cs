using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Persistence.Context;
using Warehouse.Persistence.Entities;

namespace Warehouse.Persistence.Repositories
{
        class SquadRepository : ISquadRepository
        {
                private readonly WarehouseContext _warehouseContext;

                public SquadRepository(WarehouseContext warehouseContext)
                {
                        _warehouseContext = warehouseContext;
                }

                public async Task<Squad> AddSquadAsync(Squad squad)
                {
                        var result = await _warehouseContext.Squads.AddAsync(squad);
                        await _warehouseContext.SaveChangesAsync();
                        return null; // ? czy null jest ok ? 
                }

                public async Task<Squad> DelateSquadAsync(Guid Id)
                {
                        var result = await _warehouseContext.Squads
                                .FirstOrDefaultAsync(Squad => Squad.Id == Id);

                        _warehouseContext.Squads.Remove(result);
                        await _warehouseContext.SaveChangesAsync();
                        return null;
                }

                public async Task<IEnumerable<Squad>> GetAllSquadsAsync(CancellationToken cancellationToken)
                {
                        return await _warehouseContext.Squads
                                .ToListAsync(cancellationToken);
                }

                public async Task<Squad> GetSquadAsync(Guid Id)
                {
                        return await _warehouseContext.Squads
                                .FirstOrDefaultAsync(squad => squad.Id == Id);
                }

                public Task<Squad> UpdateSquadAsync(Squad squad)
                {
                        throw new NotImplementedException();
                }
        }
}
