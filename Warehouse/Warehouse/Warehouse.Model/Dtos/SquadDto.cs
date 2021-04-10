﻿using Warehouse.Persistence.Entities;

namespace Warehouse.Model.Dtos
{
    public sealed class SquadDto
    {
        private SquadDto(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        //ToDo
        //public ICollection<User> Users { get; set; }

        public static explicit operator SquadDto(Squad squad)
                =>new (squad.Name);
    }
}
