using System;
using Warehouse.Persistence.Entities.Item.Entities;

namespace Warehouse.Model.Dtos
{
    public sealed class LoanHistoryDto
    {
        private LoanHistoryDto(DateTime timestamp, Guid itemId, Guid borrowerId, Guid receiverId)
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

        public static explicit operator LoanHistoryDto(LoanHistory loanHistory)
                => new (
                    loanHistory.Timestamp,
                    loanHistory.ItemId,
                    loanHistory.BorrowerId,
                    loanHistory.ReceiverId);
    }
}
