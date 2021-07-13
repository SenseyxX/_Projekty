using System;
using Warehouse.Persistence.Entities.User;

namespace Warehouse.Model.Contracts.Commands
{
    public sealed class CreateUserCommand
    {
        public string Name { get; init; }
        public string LastName { get; init; }
        public string Password { get; init; }
        public string Email { get; init; }
        public string PhoneNumber { get; init; }
        public Guid SquadId { get; init; }
        public PermissionLevel PermissionLevel { get; init; }
        public Guid TeamId { get; set; }
        
    }
}
