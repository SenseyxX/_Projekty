using System;

namespace Warehouse.Application.Contracts.Commands
{
    public sealed class CreateLoanHistoryCommand
    {
        public DateTime Timestamp { get; init; }
    }
}
