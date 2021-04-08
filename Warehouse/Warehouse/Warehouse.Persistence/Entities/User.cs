using System;
using System.Collections.Generic;


namespace Warehouse.Persistence.Entities
{
    public sealed class User : Entity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid SquadId { get; set; }
        public Guid RoleId { get; set; }
        public Role.Role Role { get; set; }
        public ICollection<Item> OwnedItems { get; set; }
        public ICollection<Item> StoredItems { get; set; }
    }
}
