using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VendorDeck.Application.Dtos;
using VendorDeck.Application.Features.Commands.Basket.AddItemToBasket;
using VendorDeck.Application.Features.Commands.Basket.CreateBasket;
using VendorDeck.Application.Features.Commands.Basket.RemoveItemFromBasket;
using VendorDeck.Application.Features.Queries.Basket.GetBasket;
using VendorDeck.Application.Features.Queries.Product.GetProduct;
using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet(Name = "GetBasket")]
        public async Task<IActionResult> GetBasket()
        {
            var buyerId = User.Identity?.Name ?? Request.Cookies["buyerId"];

            if (string.IsNullOrEmpty(buyerId))
            {
                Response.Cookies.Delete("buyerId");
                return Ok();
            }

            var getBasketRequest = new GetBasketQueryRequest { BuyerId = buyerId };
            var basket = await _mediator.Send(getBasketRequest);
         
            return Ok(basket);
        }

        [HttpPost]
        public async Task<IActionResult> AddToBasket([FromBody] AddBasketDto basketItem)
        {
            var buyerId = User.Identity?.Name ?? Request.Cookies["buyerId"];

            var addItemToBasketRequest = new AddItemToBasketCommandRequest { BuyerId = buyerId, ProductId = basketItem.ProductId, Quantity = basketItem.Quantity };
            var addToBasketResponse = await _mediator.Send(addItemToBasketRequest);

            if(addToBasketResponse.SetNewBuyerId) 
            {
                var cookieOptions = new CookieOptions
                {
                    IsEssential = true,
                    Expires = DateTime.Now.AddDays(30),
                };
                Response.Cookies.Append("buyerId", addToBasketResponse.NewBuyerId, cookieOptions);
            }

            return addToBasketResponse.Success ? Ok(addToBasketResponse) : BadRequest("Error creating basket");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBasketItem(int productId, int quantity)
        {
            var buyerId = User.Identity?.Name ?? Request.Cookies["buyerId"];

            if (string.IsNullOrEmpty(buyerId))
                return BadRequest("Buyer Not Found");

            var getBasketQueryRequest = new GetBasketQueryRequest { BuyerId = buyerId };

            var basketResponse = await _mediator.Send(getBasketQueryRequest);

            if (basketResponse.Basket == null)
            {
                return NotFound("Basket not found");
            }

            var removeItemFromBasketRequest = new RemoveItemFromBasketRequest { BuyerId = buyerId, ProductId = productId, Quantity = quantity };

            await _mediator.Send(removeItemFromBasketRequest);

            return NoContent();
        }
    }
}
