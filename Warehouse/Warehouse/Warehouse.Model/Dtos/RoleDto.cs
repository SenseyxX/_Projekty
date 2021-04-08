using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Persistence.Entities.Role;

namespace Warehouse.Model.Dtos
{
        class RoleDto
        {
                public RoleDto(string name, string description)
                {
                        Name = name;
                        Description = description;
                }

                public string Name { get; set; }        
                public string Description { get; set; }
                //public PerrmissionLevel PermissionLevel { get; set; }

                public static explicit operator RoleDto(Role role)
                        =>new (role.Name,role.Description);
        }
}
