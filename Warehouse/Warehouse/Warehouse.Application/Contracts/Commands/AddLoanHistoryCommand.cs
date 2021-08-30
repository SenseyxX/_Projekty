using System;

namespace Warehouse.Application.Contracts.Commands
{
    public sealed class AddLoanHistoryCommand
    {
        public DateTime Timestamp { get; init; }
    }
}
