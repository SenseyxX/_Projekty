using System;

namespace Warehouse.Application.Contracts.Commands.User
{
    public sealed class PayDueCommand
    {
        public Guid UserId { get; set; }
        public Guid DueId { get; set; }
    }
}
