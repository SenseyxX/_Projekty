using System;
using Warehouse.Persistence.Entities;
using Warehouse.Persistence.Entities.Item.Entities;

namespace Warehouse.Persistence.Factories
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
