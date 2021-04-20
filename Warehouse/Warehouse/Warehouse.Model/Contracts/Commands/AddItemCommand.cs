using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Model.Contracts.Commands
{
    public sealed class AddItemCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
