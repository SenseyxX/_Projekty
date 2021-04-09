using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Model.Dtos;

namespace Warehouse.Model.Services
{
    public interface IRoleService
    {
        Task<RoleDto> GetRoleAsync(Guid Id);
    }
}
