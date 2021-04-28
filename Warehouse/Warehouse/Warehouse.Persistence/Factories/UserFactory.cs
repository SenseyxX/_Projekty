using System;
using Warehouse.Persistence.Entities;

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
            Guid squadId,
            Guid roleId)
            => new (Guid.NewGuid(), name, lastname, passwordHash, email, phoneNumber, squadId, roleId);
    }
}
