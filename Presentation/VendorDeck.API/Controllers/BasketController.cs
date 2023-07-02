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
                return NotFound();
            }

            var getBasketRequest = new GetBasketQueryRequest { BuyerId = buyerId };
            var basket = await _mediator.Send(getBasketRequest);
         
            return Ok(basket);
        }

        [HttpPost]
        public async Task<IActionResult> AddToBasket([FromBody] AddBasketDto basketItem)
        {
            var getProductRequest = new GetProductQueryRequest { ProductId = basketItem.ProductId };
            var productResponse = await _mediator.Send(getProductRequest);

            if (productResponse.Product == null)
                return NotFound();

            var buyerId = User.Identity?.Name ?? Request.Cookies["buyerId"];
            var getBasketQueryRequest = new GetBasketQueryRequest { BuyerId = buyerId };

            if (!string.IsNullOrEmpty(buyerId))
            {
                var basketResponse = await _mediator.Send(getBasketQueryRequest);

                if (basketResponse?.Basket != null)
                {
                    var addItemToBasketRequest = new AddItemToBasketCommandRequest { Basket = basketResponse.Basket, Product = productResponse.Product, Quantity = basketItem.Quantity };
                    var addToBasketResponse = await _mediator.Send(addItemToBasketRequest);

                    return addToBasketResponse.Success ?  NoContent() : BadRequest("Error adding item to basket");
                }
            }

            buyerId ??= Guid.NewGuid().ToString();

            var cookieOptions = new CookieOptions
            {
                IsEssential = true,
                Expires = DateTime.Now.AddDays(30),
            };

            Response.Cookies.Append("buyerId", buyerId, cookieOptions);

            // create new basket 
            var newBasket = new Basket
            {
                BuyerId = buyerId,
                BasketItems = { new BasketItem { Quantity = basketItem.Quantity, ProductId = basketItem.ProductId } }
            };

            var createbasketRequest = new CreateBasketCommandRequest { Basket = newBasket };
            var addBasketResult = await _mediator.Send(createbasketRequest);

            return addBasketResult.Success ? Ok(newBasket) : BadRequest("Error creating basket");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBasketItem(int productId, int quantity)
        {
            var buyerId = Request.Cookies["buyerId"];

            if (string.IsNullOrEmpty(buyerId))
                return BadRequest("Buyer Not Found");

            var getBasketQueryRequest = new GetBasketQueryRequest { BuyerId = buyerId };

            var basketResponse = await _mediator.Send(getBasketQueryRequest);

            if (basketResponse.Basket == null)
            {
                return NotFound("Basket not found");
            }

            var removeItemFromBasketRequest = new RemoveItemFromBasketRequest { Basket = basketResponse.Basket, ProductId = productId, Quantity = quantity };

            await _mediator.Send(removeItemFromBasketRequest);

            return NoContent();
        }
    }
}
