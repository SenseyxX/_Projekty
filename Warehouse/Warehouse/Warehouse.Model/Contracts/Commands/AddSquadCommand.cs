using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Model.Contracts.Commands
{
    public sealed class AddSquadCommand
    {
        public String Name { get; set; }
    }
}
