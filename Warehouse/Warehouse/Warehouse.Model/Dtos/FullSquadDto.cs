using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Persistence.Entities;

namespace Warehouse.Model.Dtos
{
    public sealed class FullSquadDto : SquadDto
    {
        private FullSquadDto(
            Guid id,
            string name)
        {
            Name = name;
        }
        //ToDo
        //public ICollection<User> Users { get; set; }

        public static explicit operator FullSquadDto(Squad squad)
                => new(squad.Id,
                    squad.Name);
    }
}
