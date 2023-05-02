using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Warehouse.Application.Services;
using Warehouse.Application.Settings;
using Warehouse.Domain.User.Entities;

namespace Warehouse.Infrastructure.Services
{
    public sealed class TokenService : ITokenService
    {
        public const string TokenOwnerIdKey = "TokenOwner";
		public const string TokenSquadIdKey = "SquadId";

        internal const string SecretKey = "jalhdkagASdlh212312";

        private readonly TokenSettings _tokenSettings;

        public TokenService(IOptions<TokenSettings> tokenSettings)
        {
            _tokenSettings = tokenSettings.Value;
        }

        public string GenerateToken(User user)
        {
            var secretKey = Encoding.ASCII.GetBytes(SecretKey);
            var validityTimeInHours = Convert.ToDouble(_tokenSettings.ValidityTimeInHours);
            var claims = new List<Claim>
            {
                new (TokenOwnerIdKey, user.Id.ToString()),
				new (TokenSquadIdKey, user.SquadId.ToString()),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(validityTimeInHours),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(secretKey),
                    SecurityAlgorithms.HmacSha256Signature),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}