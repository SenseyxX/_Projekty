using System;
using Warehouse.Persistence.Entities.Abstractions;

namespace Warehouse.Persistence.Entities.Role
{
    public sealed class Role : Aggregate
    {
        public Role(
            Guid id,
            string name,
            string description,
            PermissionLevel permissionLevel)
            : base(id)
        {
            Name = name;
            Description = description;
            PermissionLevel = permissionLevel;
        }

        public string Name { get; }
        public string Description { get; }
        public PermissionLevel PermissionLevel { get; }
    }
}
