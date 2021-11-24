using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Squad;
using Warehouse.Domain.Squad.Entities;
using Warehouse.Infrastructure.Persistence.Context;

namespace Warehouse.Infrastructure.Repositories
{
    public sealed class SquadRepository : Repository<Squad>, ISquadRepository
    {
        public SquadRepository(WarehouseContext warehouseContext)
            : base(warehouseContext)
        {            
        }

        public override async Task<Squad> GetAsync(Guid squadId, CancellationToken cancellationToken)
            => await DbContext
                .Set<Squad>()
                .Include(squad => squad.Teams)
                .FirstOrDefaultAsync(squad => squad.Id == squadId, cancellationToken);
      
        public async Task<Team> GetTeamAsync(Guid teamId, CancellationToken cancellationToken)
            => await DbContext
                .Set<Team>()
                .FirstOrDefaultAsync(team => team.Id == teamId);
    }
}
