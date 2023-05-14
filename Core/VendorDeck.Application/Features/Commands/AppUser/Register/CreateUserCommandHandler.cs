using MediatR;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using VendorDeck.Application.Constants;
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
            var memberRole = RoleTypes.Member;

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

            IdentityResult addRoleResponse = null;

            try
            {
                addRoleResponse = await _userManager.AddToRoleAsync(appUser, memberRole);

            }
            catch (Exception ex)
            {
                result.ErrorMessages.Add(ex.Message);
                throw new AssignUserToRoleException(appUser.UserName,RoleTypes.Member);
            }

            if (!addRoleResponse.Succeeded)
            {
                var errorMessage = string.Join(",", addRoleResponse.Errors.Select(x => x.Description));

            }

            return result;
        }
    }
}
