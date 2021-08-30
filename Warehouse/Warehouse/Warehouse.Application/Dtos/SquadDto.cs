using System;
using Warehouse.Domain.Category.Enumeration;
using Warehouse.Domain.Squad.Entities;

namespace Warehouse.Application.Dtos
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

        public static explicit operator SquadDto(Squad squad)
            => new (
                squad.Id,
                squad.Name,
                squad.CategoryState);
    }
}
