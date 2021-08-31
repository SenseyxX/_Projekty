using System;

namespace Warehouse.Application.Contracts.Commands
{
    public sealed class LoanItemCommand
    {
        public Guid ItemId { get; set; }
        public Guid ReceiverId { get; init; }
    }
}
