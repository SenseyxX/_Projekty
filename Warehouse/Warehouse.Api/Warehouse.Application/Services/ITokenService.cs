using Warehouse.Domain.User.Entities;

namespace Warehouse.Application.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}