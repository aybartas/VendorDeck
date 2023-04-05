using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Application.Dtos;
using VendorDeck.Application.Token;

namespace VendorDeck.Infrastructure.Services
{

    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration configuration;
        public TokenHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public TokenDto CreateAccessToken(int lifeTimeDays)
        {
            var token = new TokenDto();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:SecretKey"]));
            var signInCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            token.ExpireDate = DateTime.UtcNow.AddDays(lifeTimeDays);

            var securityToken = new JwtSecurityToken(
                issuer: configuration["JwtConfig:ValidIssuer"].ToString(),
                expires:token.ExpireDate,
                notBefore:DateTime.UtcNow,
                signingCredentials:signInCredentials
                );

            var handler = new JwtSecurityTokenHandler();
            var jwtToken =  handler.WriteToken(securityToken);

            token.AccessToken = jwtToken;
            return token;

        }
    }
}
