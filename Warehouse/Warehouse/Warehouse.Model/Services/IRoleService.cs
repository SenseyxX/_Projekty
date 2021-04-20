using System;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Dtos;

namespace Warehouse.Model.Services
{
    public interface IRoleService
    {
        Task<RoleDto> GetRoleAsync(Guid id, CancellationToken cancellationToken);
    }
}
