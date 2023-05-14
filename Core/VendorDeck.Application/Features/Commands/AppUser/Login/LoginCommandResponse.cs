using VendorDeck.Application.Dtos;

namespace VendorDeck.Application.Features.Commands.AppUser.Login
{
    public class LoginCommandResponse
    {
        public bool IsSuccess { get; set; }
        public TokenDto Token { get; set; }
        public string Username { get; set; }
    }
}
