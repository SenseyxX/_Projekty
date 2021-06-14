using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Warehouse.Model.Helpers
{
    public sealed class TokenService
    {
        private const string SecretKey = "jalhdkagASdlh212312";
        private const string TokenOwnerKey = "TokenOwner";

        private readonly TokenSettings _tokenSettings;

        public TokenService(IOptions<TokenSettings> tokenSettings)
        {
            _tokenSettings = tokenSettings.Value;
        }

        public string GenerateToken(Guid ownerId)
        {
            var secretKey = Encoding.ASCII.GetBytes(SecretKey);
            var validityTimeInHours = Convert.ToDouble(_tokenSettings.ValidityTimeInHours);
            var claims = new List<Claim>
            {
                new (TokenOwnerKey, ownerId.ToString()),
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
