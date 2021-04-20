using System;
using Warehouse.Persistence.Entities.Role;

namespace Warehouse.Model.Dtos
{
    public sealed class RoleDto
    {
        
        public RoleDto(
        Guid id,
        string name,
        string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        //ToDo
        //public PerrmissionLevel PermissionLevel { get; set; }

        public static explicit operator RoleDto(Role role)
                => new (
                role.Id,
                role.Name,
                role.Description);
    }
}
