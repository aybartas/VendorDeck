using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System.IO;
using System.Threading.Tasks;
using VendorDeck.Application.Abstractions.Services;
using VendorDeck.Application.Dtos;
using VendorDeck.Application.Features.Commands.Payment.CreatePaymentIntent;
using VendorDeck.Application.Features.Commands.Payment.ProcessPayment;

namespace VendorDeck.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<BasketDto>> SavePaymentIntent()
        {
            var request = new SavePaymentIntentCommandRequest { UserName = User.Identity.Name };
            var response = await _mediator.Send(request);

            return response.Success ? Ok(response) : BadRequest(new ProblemDetails { Title= "Problem saving payment intent"});
        }

        [HttpPost("webhook")]
        public async Task<ActionResult> StripeWebHooks()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            var processPaymentCommandRequest = new ProcessPaymentCommandRequest
            {
                StripeResponse = json,
                StripeSigniture = Request.Headers["Stripe-Signature"]
            };

            var response = _mediator.Send(processPaymentCommandRequest);

            return Ok(response);
        }
    }
}
