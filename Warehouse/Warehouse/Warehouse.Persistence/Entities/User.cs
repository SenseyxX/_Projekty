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
        public Role.Role Role { get; set; } // error przy braku :	'Role' is a namespace but is used like a type Warehouse.Persistence C:\Users\Oskar\source\_Projekty\Warehouse\Warehouse\Warehouse.Persistence\Entities\User.cs	16	Active
        public ICollection<Item> OwnedItems { get; set; }
        public ICollection<Item> StoredItems { get; set; }
    }
}
