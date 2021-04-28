using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Contracts.Commands;
using Warehouse.Model.Dtos;

namespace Warehouse.Model.Services
{
    public interface ISquadService
    {
        Task<IEnumerable<SquadDto>> GetSquadsAsync(CancellationToken cancellationToken);
        Task<SquadDto> GetSquadAsync(Guid id, CancellationToken cancellationToken);
        Task AddSquadAsync(AddSquadCommand addSquadCommand, CancellationToken cancellationToken);
        Task UpdateSquadAsync(UpdateSquadCommand updateSquadCommand, CancellationToken cancellationToken);
        Task DeleteSquadAsync(Guid id, CancellationToken cancellationToken);
    }
}
