using VendorDeck.Application.Dtos;

namespace VendorDeck.Application.Features.Commands.AppUser.Login
{
    public class LoginCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string Token { get; set; }

    }
}
