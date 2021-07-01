using System;
using Warehouse.Persistence.Entities;

namespace Warehouse.Model.Dtos
{
    public class SquadDto
    {
        protected SquadDto(Guid id,
                           string name,
                           State state)
        {
            Id = id;
            Name = name;
            State = state;
        }
        public Guid Id { get; }
        public string Name { get;  }
        public State State { get;  }

        public static explicit operator SquadDto(Squad squad)
            => new (squad.Id,
                    squad.Name,
                    squad.State);
    }
}
