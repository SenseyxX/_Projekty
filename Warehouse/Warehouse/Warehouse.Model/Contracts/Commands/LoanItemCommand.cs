using System;

namespace Warehouse.Model.Contracts.Commands
{
    public sealed class LoanItemCommand
    {
        public Guid ItemId { get; init; }
        public Guid ReceiverId { get; init; }
    }
}
