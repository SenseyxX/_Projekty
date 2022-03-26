using System;
using Warehouse.Domain.Category.Enumeration;

namespace Warehouse.Application.Dtos.Squad
{
    public class SquadDto
    {
        protected SquadDto(
            Guid id,
            string name,
            Guid? squadOwnerId,
            State state)
        {
            Id = id;
            Name = name;
            SquadOwnerId = squadOwnerId;
            State = state;
        }

        public Guid Id { get; }
        public string Name { get;  }
        public Guid? SquadOwnerId { get; }
        public State State { get;  }

        public static explicit operator SquadDto(Domain.Squad.Entities.Squad squad)
            => new(
                squad.Id,
                squad.Name,
                squad.SquadOwnerId,
                squad.State);
    }
}
