using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Application.Dtos.User;
using Warehouse.Application.Services;
using Warehouse.Domain.User;

namespace Warehouse.Application.Handlers
{
    public sealed class AuthenticationHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncryptionService _encryptionService;
        private readonly ITokenService _tokenService;

        public AuthenticationHandler(IUserRepository userRepository, IEncryptionService encryptionService, ITokenService tokenService)
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

            if (isAuthenticated == true)
            {
                return new AuthenticationResultDto
                {
                    IsAuthenticated = isAuthenticated,
                    Jwt = _tokenService.GenerateToken(user),
                    TokenOwner = (UserDto) user,
                };
            }
            return new AuthenticationResultDto{IsAuthenticated = isAuthenticated};
        }
    }
}