using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Dtos;
using Warehouse.Persistence.Entities;

namespace Warehouse.Model.Services
{
    public interface ISquadService
    {
        Task<IEnumerable<SquadDto>> GetSquadsAsync(CancellationToken cancellationToken);
        Task<SquadDto> GetSquadAsync(Guid Id);
        Task<SquadDto> AddSquadAsync(Squad squad);
        Task UpdateSquadAsync(Squad squad, Guid Id);
        Task DeleteSquadAsync(Guid Id);        
    }
}
