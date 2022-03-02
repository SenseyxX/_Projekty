using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Domain.Abstractions;
using Warehouse.Domain.Squad.Entities;

namespace Warehouse.Domain.Squad
{
    public interface ISquadRepository : IRepository<Entities.Squad>
    {
        Task<Team> GetTeamAsync(Guid teamId, CancellationToken cancellationToken);
        Task<Entities.Squad> GetByOwnerId(Guid squadOwnerId, CancellationToken cancellationToken);
    }
}
