using System;

namespace Warehouse.Model.Contracts.Commands
{
    public sealed class LoanItemCommand
    {
        public Guid ItemId { get; set; }
        public Guid ReceiverId { get; set; }
    }
}
