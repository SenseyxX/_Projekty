using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Model.Contracts.Commands
{
    public sealed class AddLoanHistoryCommand
    {
        public DateTime Timestamp { get; set; }
    }
}
