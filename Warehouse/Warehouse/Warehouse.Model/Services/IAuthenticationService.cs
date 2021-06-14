using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Dtos;

namespace Warehouse.Model.Services
{
    public interface IAuthenticationService
    {
        public Task<AuthenticationResultDto> AuthenticateAsync(string email, string password, CancellationToken cancellationToken);
    }
}
