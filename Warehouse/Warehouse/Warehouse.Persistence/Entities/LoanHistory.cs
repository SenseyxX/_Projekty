using System;

namespace Warehouse.Persistence.Entities
{
    public sealed class LoanHistory : Entity
    {
        public DateTime Timestamp { get; set; }
        public Guid ItemId { get; set; }
        public Guid BorrowerId { get; set; }
        public Guid ReceiverId { get; set; }
    }
}
