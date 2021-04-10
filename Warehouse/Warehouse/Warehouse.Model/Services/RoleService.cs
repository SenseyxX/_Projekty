using System;
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
        public async Task<RoleDto> GetRoleAsync(Guid Id)
        {
            var result = await _roleRepository.GetRoleAsync(Id);
            return (RoleDto)result;
        }
    }
}
