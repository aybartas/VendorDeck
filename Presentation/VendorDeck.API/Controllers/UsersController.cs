using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;
using VendorDeck.Application.Features.Commands.AppUser.Login;
using VendorDeck.Application.Features.Commands.AppUser.Register;
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

        [HttpPost]
        public async Task <IActionResult> CreateUser(CreateUserCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
