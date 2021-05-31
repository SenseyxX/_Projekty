using System;

namespace Warehouse.Model.Contracts.Commands
{
    public sealed class UpdateUserCommand
    {
        public Guid UserId { get; set; }
        public string Name { get; }
        public string LastName { get; }
        public string Email { get; }
        public string PhoneNumber { get; }
        public string PasswordHash { get; set; }
    }
}
