using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Persistence.Entities.Role;

namespace Warehouse.Persistence.Repositories
{
    public interface IRoleRepository
    {
        Task<Role> GetRoleAsync(Guid Id);
    }
}
