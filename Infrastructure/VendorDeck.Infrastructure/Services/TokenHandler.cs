using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VendorDeck.Application.Dtos;
using VendorDeck.Application.Token;
using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.Infrastructure.Services
{

    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<AppUser> userManager;

        public TokenHandler(IConfiguration configuration, UserManager<AppUser> userManager)
        {
            this.configuration = configuration;
            this.userManager = userManager;
        }
        public async Task<TokenDto> CreateAccessToken(AppUser user, double? lifeTimeDays = 5)
        {
            var token = new TokenDto();
            var expireDate = DateTime.UtcNow.AddDays(lifeTimeDays.Value);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:SecretKey"]));
            var signInCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var roles = await userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var securityToken = new JwtSecurityToken(
                issuer: configuration["JwtConfig:ValidIssuer"].ToString(),
                expires: expireDate,
                claims: claims,
                notBefore: DateTime.UtcNow,
                signingCredentials: signInCredentials
                );

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.WriteToken(securityToken);

            token.ExpireDate = expireDate;
            token.AccessToken = jwtToken;
            return token;

        }
    }
}
