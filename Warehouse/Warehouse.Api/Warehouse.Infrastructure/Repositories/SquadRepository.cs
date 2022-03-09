using System;
using System.Linq;
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
            => await GetSquadDependencies()
                .FirstOrDefaultAsync(squad => squad.Id == squadId, cancellationToken);

        public async Task<Team> GetTeamAsync(Guid teamId, CancellationToken cancellationToken)
            => await DbContext
                .Set<Team>()
                .FirstOrDefaultAsync(team => team.Id == teamId);

        public async Task<Squad> GetByOwnerId(Guid squadOwnerId, CancellationToken cancellationToken)
            => await GetSquadDependencies()
                .FirstOrDefaultAsync(squad => squad.SquadOwnerId == squadOwnerId, cancellationToken);

        private IQueryable<Squad> GetSquadDependencies()
            => DbContext
                .Set<Squad>()
                .AsNoTracking()
                .Include(squad => squad.Users)
                .Include(squad => squad.Teams)
                    .ThenInclude(team => team.Users);
    }
}
