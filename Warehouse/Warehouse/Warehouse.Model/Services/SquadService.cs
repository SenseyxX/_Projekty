using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Contracts.Commands;
using Warehouse.Model.Dtos;
using Warehouse.Persistence.Entities;
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

        public async Task DeleteSquadAsync(Guid Id)
            => throw new NotImplementedException();

        public async Task<FullSquadDto> GetSquadAsync(Guid id, CancellationToken cancellationToken)
            => (FullSquadDto)await _squadRepository.GetAsync(id, cancellationToken);

        public async Task<IEnumerable<SquadDto>> GetSquadsAsync(CancellationToken cancellationToken)
        {
            var result = await _squadRepository.GetRangeAsync(cancellationToken);
            return result.Select(squad => (SquadDto)squad);
        }

        public Task UpdateSquadAsync(UpdateSquadCommand updateSquadCommand, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
