using System;
using Warehouse.Persistence.Entities;

namespace Warehouse.Model.Dtos
{
    public class SquadDto
    {
        private SquadDto(Guid id,string name)
        {
            Id = id;
            Name = name;
        }
        public Guid Id { get; }
        public string Name { get;  }

        public static explicit operator SquadDto(Squad squad)
            => new (squad.Id, squad.Name);
    }
}
