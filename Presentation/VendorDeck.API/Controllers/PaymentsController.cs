using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VendorDeck.Application.Abstractions.Services;
using VendorDeck.Application.Dtos;
using VendorDeck.Application.Features.Commands.Payment.CreatePaymentIntent;

namespace VendorDeck.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<BasketDto>> SavePaymentIntent()
        {
            var request = new SavePaymentIntentCommandRequest { UserName = User.Identity.Name };
            var response = await _mediator.Send(request);

            return response.Success ? Ok(response) : BadRequest(new ProblemDetails { Title= "Problem saving payment intent"});
        }
    }
}
