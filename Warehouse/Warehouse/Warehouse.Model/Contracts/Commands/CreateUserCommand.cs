using System;
using Warehouse.Persistence.Entities.User;

namespace Warehouse.Model.Contracts.Commands
{
    public sealed class CreateUserCommand
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid SquadId { get; init; }
        public Guid TeamId { get; set; }
        public PermissionLevel PermissionLevel { get; set; }
    }
}
