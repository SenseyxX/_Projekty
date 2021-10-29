using System;

namespace Warehouse.Application.Services
{
    public interface ITokenService
    {
        string GenerateToken(Guid ownerId);
    }
}
