using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VendorDeck.Application.Dtos;
using VendorDeck.Application.Features.Commands.Order.CreateOrder;
using VendorDeck.Application.Features.Queries.Order.GetOrder;
using VendorDeck.Application.Features.Queries.Order.GetOrders;

namespace VendorDeck.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var request = new GetOrdersQueryRequest();
            var response = _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDto order)
        {
            order.BuyerId = User.Identity.Name;

            var request = new CreateOrderCommandRequest
            {
                Order = order,
            };

            var response = _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOrderById(string id)
        {
            var request = new GetOrderQueryRequest
            {
                Username = User.Identity.Name,
                Id = int.Parse(id)
            };
            var response = _mediator.Send(request);

            return Ok(response);
        }

    }
}
