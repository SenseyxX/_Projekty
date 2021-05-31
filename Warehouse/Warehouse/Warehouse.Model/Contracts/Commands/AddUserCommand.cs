using Warehouse.Persistence.Entities.Role;

namespace Warehouse.Model.Contracts.Commands
{
    public sealed class AddUserCommand
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public PermissionLevel PermissionLevel { get; set; }
    }
}
