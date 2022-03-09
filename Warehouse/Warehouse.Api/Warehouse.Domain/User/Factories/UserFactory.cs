using System;
using Warehouse.Domain.Category.Enumeration;
using Warehouse.Domain.User.Enumeration;

namespace Warehouse.Domain.User.Factories
{
    public static class UserFactory
    {
        public static Entities.User Create(
            string name,
            string lastname,
            byte[] passwordHash,
            string email,
            string phoneNumber,
            PermissionLevel permissionLevel,
            Guid? squadId,
            Guid? teamId)
            => new (
                Guid.NewGuid(),
                name,
                lastname,
                passwordHash,
                email,
                phoneNumber,
                permissionLevel,
                State.Active,
                squadId,
                teamId);
    }
}
