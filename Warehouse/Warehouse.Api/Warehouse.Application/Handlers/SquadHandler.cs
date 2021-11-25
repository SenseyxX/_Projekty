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
        private readonly TeamDomainService _teamDomainService;

        public SquadHandler(ISquadRepository squadRepository, TeamDomainService teamDomainService)
        {
            _squadRepository = squadRepository;
            _teamDomainService = teamDomainService;
        }

        public async Task CreateSquadAsync(
            CreateSquadCommand createSquadCommand,
            CancellationToken cancellationToken)
        {
            var squad = SquadFactory.Create(createSquadCommand.SquadOwnerId, createSquadCommand.Name);
            await _squadRepository.CreateAsync(squad, cancellationToken);
            await _squadRepository.SaveAsync(cancellationToken);
        }

        public async Task CreateTeamAsync(
            CreateTeamCommand createTeamCommand,
            CancellationToken cancellationToken)
        {
            var squad = await _teamDomainService.CreateTeamAsync(createTeamCommand.Name,
                                                                createTeamCommand.TeamOwnerId,
                                                                createTeamCommand.SquadId,
                                                                createTeamCommand.Description,
                                                                cancellationToken);
             _squadRepository.Update(squad);
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

        public async Task DeleteTeamAsync(Guid squadId, Guid teamId, CancellationToken cancellationToken)
        {
            var team = await _teamDomainService.DeleteTeamAsync(squadId, teamId, cancellationToken);
            
            _squadRepository.Update(team);
            await _squadRepository.SaveAsync(cancellationToken);
        }

        public async Task<FullSquadDto> GetSquadAsync(Guid id, CancellationToken cancellationToken)
            => (FullSquadDto) await _squadRepository.GetAsync(id, cancellationToken);
        
        public async Task<FullTeamDto> GetTeamAsync(Guid teamId, CancellationToken cancellationToken)
            => (FullTeamDto) await _squadRepository.GetTeamAsync(teamId, cancellationToken);
        
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
            isUpdated = squad.UpdateSquadOwnerId(updateSquadCommand.SquadOwnerId);
            
            if (isUpdated)
            {
                _squadRepository.Update(squad);
                await _squadRepository.SaveAsync(cancellationToken);
            }
        }

        public async Task UpdateTeamAsync(
            UpdateTeamCommand updateTeamCommand,
            CancellationToken cancellationToken)
        {
            var team = await _squadRepository.GetAsync(updateTeamCommand.SquadId, cancellationToken);
            var isUpdated = team.UpdateTeamName(updateTeamCommand.TeamId, updateTeamCommand.Name);
            isUpdated = team.UpdateTeamOwner(updateTeamCommand.TeamId, updateTeamCommand.TeamOwnerId);
            isUpdated = team.UpdateTeamPoints(updateTeamCommand.TeamId, updateTeamCommand.Points);
            isUpdated = team.UpdateTeamDescription(updateTeamCommand.TeamId, updateTeamCommand.Description);
            
            if (isUpdated)
            {
                _squadRepository.Update(team);
                await _squadRepository.SaveAsync(cancellationToken);
            }
        }
    }
}
