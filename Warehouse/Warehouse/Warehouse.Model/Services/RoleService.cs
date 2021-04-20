using System;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Dtos;
using Warehouse.Persistence.Repositories;

namespace Warehouse.Model.Services
{
    public sealed class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<RoleDto> GetRoleAsync(Guid id, CancellationToken cancellationToken)
            => (RoleDto)await _roleRepository.GetAsync(id, cancellationToken);        
    }
}
