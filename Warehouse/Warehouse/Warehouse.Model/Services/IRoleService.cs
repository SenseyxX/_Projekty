using System;
using System.Threading.Tasks;
using Warehouse.Model.Dtos;

namespace Warehouse.Model.Services
{
    public interface IRoleService
    {
        Task<RoleDto> GetRoleAsync(Guid Id);
    }
}
