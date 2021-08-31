using System;

namespace Warehouse.Application.Contracts.Commands
{
    public sealed class UpdateUserCommand
    {
        public Guid UserId { get; set; }
        public string Name { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string PhoneNumber { get; init; }
    }
}
