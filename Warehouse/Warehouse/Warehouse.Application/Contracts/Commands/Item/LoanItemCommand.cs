using System;

namespace Warehouse.Application.Contracts.Commands.Item
{
    public sealed class LoanItemCommand
    {
        public Guid ItemId { get; set; }
        public Guid ReceiverId { get; init; }
    }
}
