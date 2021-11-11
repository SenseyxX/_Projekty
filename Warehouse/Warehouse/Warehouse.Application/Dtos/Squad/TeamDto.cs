using System;
using Warehouse.Domain.Category.Enumeration;
using Warehouse.Domain.Squad.Entities;

namespace Warehouse.Application.Dtos.Squad
{
    public class TeamDto
    {
        protected TeamDto(
            Guid id,
            string name,
            Guid squadId)
        {
            Id = id;
            Name = name;
            SquadId = squadId;
        }

        public Guid Id { get; }
        public string Name { get; }
        public Guid SquadId { get; }

        public static explicit operator TeamDto(Team team)
            => new(
                team.Id,
                team.Name,
                team.SquadId);
    }
}