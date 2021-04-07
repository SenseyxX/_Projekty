using System;
using Warehouse.Persistence.Entities.Role;
namespace Warehouse.Persistence.Entities.Role
{
    public sealed class Role : Entity
    {        
        public string Name { get; set; }    //   czy name == permissionlevel ?? 
        public string Description { get; set; }
        public  PerrmissionLevel PermissionLevel { get; set; }
              
        }
}
