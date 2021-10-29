using System;

namespace Warehouse.Application.Contracts.Commands.Item
{
    public sealed class CreateLoanHistoryCommand
    {
        public DateTime Timestamp { get; init; }
    }
}
