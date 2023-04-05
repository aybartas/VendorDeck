using MediatR;
using Microsoft.AspNetCore.Identity;
using VendorDeck.Application.Exceptions;
using VendorDeck.Application.Features.Commands.AppUser.Register;
using User = VendorDeck.Domain.Entities.Concrete.AppUser;

namespace VendorDeck.Application.Features.Commands.AppUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly UserManager<User> _userManager;

        public CreateUserCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            //TODO map with automapper
            var result = new CreateUserCommandResponse { Success= true };
            var appUser = new User
            {
                UserName = request.Username,
                Email = request.Email,
                Name = request.Name,
                Surname = request.Surname,
            };

            var response = await _userManager.CreateAsync(appUser, request.Password);

            if (!response.Succeeded)
            {
                var errorMessage = string.Join(",", response.Errors.Select(x => x.Description));
                throw new CreateUserException(errorMessage);   
            }
            return result;
        }
    }
}
