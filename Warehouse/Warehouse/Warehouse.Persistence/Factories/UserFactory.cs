using System;
using Warehouse.Persistence.Entities;
using Warehouse.Persistence.Entities.Item;
using Warehouse.Persistence.Entities.User;
using Warehouse.Persistence.Entities.User.Entities;

namespace Warehouse.Persistence.Factories
{
    public static class UserFactory
    {
        public static User Create(
            string name,
            string lastname,
            byte[] passwordHash,
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
