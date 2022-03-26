using System;
using Warehouse.Domain.Squad.Entities;

namespace Warehouse.Application.Dtos.Squad
{
    public class TeamDto
    {
        protected TeamDto(
            Guid id,
            string name,
            Guid squadId,
            Guid? teamOwnerId )
        {
            Id = id;
            Name = name;
            SquadId = squadId;
            TeamOwnerId = teamOwnerId;
        }

        public Guid Id { get; }
        public string Name { get; }
        public Guid SquadId { get; }
        public Guid? TeamOwnerId { get; }

        public static explicit operator TeamDto(Team team)
            => new(
                team.Id,
                team.Name,
                team.SquadId,
                team.TeamOwnerId);
    }
}