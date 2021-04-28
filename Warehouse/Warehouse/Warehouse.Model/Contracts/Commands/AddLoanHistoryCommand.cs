using System;

namespace Warehouse.Model.Contracts.Commands
{
    public sealed class AddLoanHistoryCommand
    {
        public DateTime Timestamp { get; set; }
    }
}
