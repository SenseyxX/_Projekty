using System;
using Warehouse.Domain.Category.Enumeration;

namespace Warehouse.Application.Dtos.Squad
{
    public class SquadDto
    {
        protected SquadDto(
            Guid id,
            string name,
            CategoryState categoryState)
        {
            Id = id;
            Name = name;
            CategoryState = categoryState;
        }

        public Guid Id { get; }
        public string Name { get;  }
        public CategoryState CategoryState { get;  }

        public static explicit operator SquadDto(Domain.Squad.Entities.Squad squad)
            => new (
                squad.Id,
                squad.Name,
                squad.CategoryState);
    }
}
