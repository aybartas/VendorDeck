﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.Application.Features.Queries.User.GetCurrentUser
{
    public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQueryRequest, GetCurrentUserQueryResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        public GetCurrentUserQueryHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<GetCurrentUserQueryResponse> Handle(GetCurrentUserQueryRequest request, CancellationToken cancellationToken)
        {

            var user = await _userManager.FindByNameAsync(request.Username);
            return new GetCurrentUserQueryResponse { AppUser = user };
        }
    }
}