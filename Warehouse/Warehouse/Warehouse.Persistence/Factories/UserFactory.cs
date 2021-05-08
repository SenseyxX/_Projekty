using System;
using Warehouse.Persistence.Entities;
using Warehouse.Persistence.Entities.Item;
using Warehouse.Persistence.Entities.Role;

namespace Warehouse.Persistence.Factories
{
    public static class UserFactory
    {
        public static User Create(
            string name,
            string lastname,
            string passwordHash,
            string email,
            string phoneNumber,
            PermissionLevel permissionLevel,    
            Guid squadId)
            => new (
                Guid.NewGuid(),
                name,
                lastname,
                passwordHash,
                email,
                phoneNumber,
                permissionLevel,
                State.Active,
                squadId);
    }
}
