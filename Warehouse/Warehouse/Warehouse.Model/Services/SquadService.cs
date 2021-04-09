using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Dtos;
using Warehouse.Persistence.Entities;
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
        public async Task<SquadDto> AddSquadAsync(Squad squad)
        {
            var result = await _squadRepository.AddSquadAsync(squad);
            return (SquadDto)result;
        }        

        public async Task DeleteSquadAsync(Guid Id)
        {
            await _squadRepository.DeleteSquadAsync(Id);
        }

        public async Task<SquadDto> GetSquadAsync(Guid Id)
        {
            var result = await _squadRepository.GetSquadAsync(Id);
            return (SquadDto)result;
        }

        public async Task<IEnumerable<SquadDto>> GetSquadsAsync(CancellationToken cancellationToken)
        {
            var result = await _squadRepository.GetAllSquadsAsync(cancellationToken);
            return result.Select(squad => (SquadDto)squad);
        }
        public Task UpdateSquadAsync(Squad squad, Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
