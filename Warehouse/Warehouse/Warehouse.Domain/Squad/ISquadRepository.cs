using System;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Domain.Abstractions;
using Warehouse.Domain.Squad.Entities;

namespace Warehouse.Domain.Squad
{
    public interface ISquadRepository : IRepository<Entities.Squad>
    {
        Task<Team> GetTeamAsync(Guid teamId, CancellationToken cancellationToken);
    }
}
