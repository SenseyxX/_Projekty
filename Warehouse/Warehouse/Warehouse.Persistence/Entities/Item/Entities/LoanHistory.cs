using System;
using Warehouse.Persistence.Entities.Abstractions;

namespace Warehouse.Persistence.Entities.Item.Entities
{
    public sealed class LoanHistory : Entity
    {
        public LoanHistory(Guid id,
            DateTime timestamp,
            Guid itemId,
            Guid borrowerId,
            Guid receiverId)
            : base(id)
        {
            Timestamp = timestamp;
            ItemId = itemId;
            BorrowerId = borrowerId;
            ReceiverId = receiverId;
        }

        public DateTime Timestamp { get; }
        public Guid ItemId { get; }
        public Guid BorrowerId { get; }
        public Guid ReceiverId { get; }
    }
}
