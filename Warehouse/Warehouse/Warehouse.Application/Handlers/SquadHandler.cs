using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Application.Contracts.Commands.Squad;
using Warehouse.Application.Dtos.Squad;
using Warehouse.Domain.Squad;
using Warehouse.Domain.Squad.Factories;

namespace Warehouse.Application.Handlers
{
    public sealed class SquadHandler
    {
        private readonly ISquadRepository _squadRepository;

        public SquadHandler(ISquadRepository squadRepository)
        {
            _squadRepository = squadRepository;
        }

        public async Task AddSquadAsync(
            CreateSquadCommand addSquadCommand,
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

        public async Task<FullSquadDto> GetSquadAsync(Guid id, CancellationToken cancellationToken)
            => (FullSquadDto) await _squadRepository.GetAsync(id, cancellationToken);

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
