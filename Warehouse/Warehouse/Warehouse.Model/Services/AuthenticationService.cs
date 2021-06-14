using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Dtos;
using Warehouse.Model.Helpers;
using Warehouse.Persistence.Repositories;

namespace Warehouse.Model.Services
{
    public sealed class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly EncryptionService _encryptionService;
        private readonly TokenService _tokenService;

        public AuthenticationService(IUserRepository userRepository, EncryptionService encryptionService, TokenService tokenService)
        {
            _userRepository = userRepository;
            _encryptionService = encryptionService;
            _tokenService = tokenService;
        }

        public async Task<AuthenticationResultDto> AuthenticateAsync(string email, string password, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetRangeAsync(cancellationToken);
            var user = users.First(user => user.Email == email);

            var isAuthenticated = _encryptionService.VerifyPassword(user.PasswordHash, password);

            return new AuthenticationResultDto
            {
                IsAuthenticated = isAuthenticated,
                Jwt = _tokenService.GenerateToken(user.Id),
                TokenOwner = (UserDto) user,
            };
        }
    }
}
