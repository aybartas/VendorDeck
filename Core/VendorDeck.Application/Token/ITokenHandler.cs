using VendorDeck.Application.Dtos;
using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.Application.Token
{
    public interface ITokenHandler
    {
        Task<TokenDto> CreateAccessToken(AppUser user, double? lifeTimeDays);
    }
}
