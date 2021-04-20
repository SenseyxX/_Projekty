using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Model.Contracts.Commands
{
    public sealed class UpdateSquadCommand
    {
        public Guid SquadId { get; set; }
        public string  Name { get; set; }
    }
}
