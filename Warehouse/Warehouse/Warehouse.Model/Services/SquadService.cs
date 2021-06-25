using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Contracts.Commands;
using Warehouse.Model.Dtos;
using Warehouse.Persistence.Factories;
using Warehouse.Persistence.Repositories;

namespace Warehouse.Model.Services
{
    public sealed class SquadService : ISquadService
    {
        private readonly ISquadRepository _squadRepository;

        public SquadService(ISquadRepository squadRepository)
        {
            _squadRepository = squadRepository;
        }
        public async Task AddSquadAsync(
            AddSquadCommand addSquadCommand,
            CancellationToken cancellationToken)
        {
            var squad = SquadFactory.Create(addSquadCommand.Name);
            await _squadRepository.CreateAsync(squad, cancellationToken);
            await _squadRepository.SaveAsync(cancellationToken);
        }

        public async Task DeleteSquadAsync(Guid id, CancellationToken cancellationToken)
        {
            var squad = await _squadRepository.GetAsync(id,cancellationToken);
            var updated = squad.Delete();

            if (updated)
            {
                _squadRepository.Update(squad);
                await _squadRepository.SaveAsync(cancellationToken);
            }
        }

        public async Task<SquadDto> GetSquadAsync(Guid id, CancellationToken cancellationToken)
            => (SquadDto) await _squadRepository.GetAsync(id, cancellationToken);

        public async Task<IEnumerable<SquadDto>> GetSquadsAsync(CancellationToken cancellationToken)
        {
            var result = await _squadRepository.GetRangeAsync(cancellationToken);
            return result.Select(squad => (SquadDto)squad);
        }

        public async Task UpdateSquadAsync(
            UpdateSquadCommand updateSquadCommand,
            CancellationToken cancellationToken)
        {
            var squad = await _squadRepository.GetAsync(updateSquadCommand.SquadId, cancellationToken);
            var isUpdated = squad.UpdateName(updateSquadCommand.Name);

            if (isUpdated)
            {
                _squadRepository.Update(squad);
                await _squadRepository.SaveAsync(cancellationToken);
            }
        }
    }
}
