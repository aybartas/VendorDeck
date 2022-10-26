using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VendorDeck.API.Config;
using VendorDeck.Entities.Dtos;

namespace VendorDeck.API.Utils
{
    public class JwtHelper
    {
        private readonly JwtConfig jwtConfig;
        public JwtHelper(IOptions<JwtConfig> jwtConfig)
        {
            this.jwtConfig = jwtConfig.Value;
        }
        public string GenerateToken(LoginDto loginDto,List<Claim> claims)
        {
            var tokenClaims = claims ?? new List<Claim>();

            tokenClaims.Add(new Claim(ClaimTypes.Name, loginDto.UserName));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.SecretKey));
            var signInCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            
            var token = new JwtSecurityToken(
                issuer: jwtConfig.ValidIssuer,
                audience: jwtConfig.ValidAudience,
                notBefore : DateTime.UtcNow,
                expires : DateTime.UtcNow.AddDays(3),
                signingCredentials: signInCredentials,
                claims : tokenClaims
                );

            var handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(token);
        }

    }
}
