using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Persistence.Entities;

namespace Warehouse.Model.Dtos
{
        class SquadDto
        {
                private SquadDto(string name)
                {
                        Name = name;
                }
                public string Name { get; set; }
                //public ICollection<User> Users { get; set; }

                public static explicit operator SquadDto(Squad squad)
                        => new (squad.Name);
        }
}
