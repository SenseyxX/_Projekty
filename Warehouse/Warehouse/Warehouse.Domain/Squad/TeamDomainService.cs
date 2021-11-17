using System;
using System.Threading;
using System.Threading.Tasks;

namespace Warehouse.Domain.Squad
{
    public sealed class TeamDomainService
    {
        private readonly ISquadRepository _squadRepository;

        public TeamDomainService(ISquadRepository squadRepository)
        {
            _squadRepository = squadRepository;
        }

        public async Task<Entities.Squad> CreateTeamAsync(
            string name,
            Guid teamOwnerId,
            Guid squadId,
            string description,
            CancellationToken cancellationToken)
        {
            var squad = await _squadRepository.GetAsync(squadId, cancellationToken)
                    ?? throw new Exception();

            squad.AddTeam(name, teamOwnerId, description);

            return squad;
        }

        public async Task<Entities.Squad> UpdateTeamAsync(
            Guid squadId,
            Guid teamId,
            string name,
            Guid teamOwnerId,
            int points,
            string description,
            CancellationToken cancellationToken)
        {
            var squad = await _squadRepository.GetAsync(squadId, cancellationToken)
                        ?? throw new Exception();
            
            squad.UpdateTeamName(squadId, name);
            squad.UpdateTeamPoints(squadId, points);
            squad.UpdateTeamDescription(squadId,description);

            return squad;
        }

        public async Task<Entities.Squad> DeleteTeamAsync(
            Guid squadId,
            Guid teamId, 
            CancellationToken cancellationToken)
        {
            var squad = await _squadRepository.GetAsync(squadId, cancellationToken) 
                        ?? throw new Exception();
            
            squad.DeleteTeam(teamId);

            return squad;
        }
    }
}