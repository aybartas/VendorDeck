﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using VendorDeck.Application.Exceptions;
using VendorDeck.Application.Token;
using User = VendorDeck.Domain.Entities.Concrete.AppUser;

namespace VendorDeck.Application.Features.Commands.AppUser.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenHandler _tokenHandler;

        public LoginCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            User appUser;

            appUser = await _userManager.FindByNameAsync(request.UsernameOrEmail);
            appUser ??= await _userManager.FindByEmailAsync(request.UsernameOrEmail);

            if (appUser is null)
                throw new UserNotFoundException(); 

            var signInResult = await _signInManager.CheckPasswordSignInAsync(appUser,request.Password,lockoutOnFailure:false);

            if (!signInResult.Succeeded)
                throw new LoginErrorException();

            var token = _tokenHandler.CreateAccessToken(5);

            return new LoginCommandResponse { Token= token };
        }
    }
}