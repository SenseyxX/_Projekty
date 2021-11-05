using System;
using Warehouse.Domain.Item.Entities;

namespace Warehouse.Domain.Item.Factories
{
    public static class LoanHistoryFactory
    {
        internal static LoanHistory Create(
            DateTime timestamp,
            Guid itemId,
            Guid borrowerId,
            Guid receiverId)
            => new (Guid.Empty, timestamp, itemId, borrowerId, receiverId);
    }
}
