using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;
using VendorDeck.Application.Features.Commands.AppUser.Login;
using VendorDeck.Application.Features.Commands.AppUser.Register;
using VendorDeck.Application.Features.Queries.User.GetCurrentUser;
using VendorDeck.Application.Token;

namespace VendorDeck.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task <IActionResult> Register(CreateUserCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommandRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);

                return Ok(response);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }

        [Authorize]
        [HttpGet("currentUser")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userName = User.Identity.Name;
            var request = new GetCurrentUserQueryRequest { Username = userName };
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
