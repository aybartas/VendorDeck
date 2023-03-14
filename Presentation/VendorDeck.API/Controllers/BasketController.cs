using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VendorDeck.Application.Dtos;
using VendorDeck.Application.Services;
using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService basketService;
        private readonly IProductService productService;

        public BasketController(IBasketService basketService, IProductService productService)
        {
            this.basketService = basketService;
            this.productService = productService;
        }

        [HttpGet(Name = "GetBasket")]
        public async Task<IActionResult> GetBasket()
        {
            return null;
            //var buyerId = Request.Cookies["buyerId"];

            //var basket = await basketService.GetBasketWithBasketItems(buyerId);

            //if (basket == null || buyerId == null)
            //{
            //    return NotFound();
            //}

            //var basketDto = mapper.Map<BasketDto>(basket);

            //return Ok(basketDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddBasket( [FromBody]AddBasketDto basketItem)
        {
            return null;

            //var product = await productService.FindByIdAsync(basketItem.ProductId);

            //if (product == null) 
            //    return NotFound();

            //var buyerId = Request.Cookies["buyerId"];
            //var basket = await basketService.GetBasketWithBasketItems(buyerId);
            
            //if(basket != null)
            //{
            //    basketService.AddItemToBasket(basket, product, basketItem.Quantity);
            //    return Created("", mapper.Map<BasketDto>(basket));
            //}
            
            //buyerId = Guid.NewGuid().ToString();
            //var cookieOptions = new CookieOptions {
            //    IsEssential = true,
            //    Expires = DateTime.Now.AddDays(30),
            //};

            //Response.Cookies.Append("buyerId", buyerId, cookieOptions);

            //// create new basket 

            //var newBasket = new Basket
            //{
            //    BuyerId = buyerId,
            //    BasketItems = { new BasketItem { Quantity = basketItem.Quantity, ProductId = basketItem.ProductId} }
            //};

            //await basketService.AddAsync(newBasket);

            //return CreatedAtRoute("GetBasket", mapper.Map<BasketDto>(newBasket));
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBasketItem(int productId, int quantity)
        {
            return null;

            //// get basket
            //var buyerId = Request.Cookies["buyerId"];

            //var basket = await basketService.GetBasketWithBasketItems(buyerId);

            //if (basket == null || buyerId == null)
            //{
            //    return NotFound();
            //}

            //await basketService.RemoveItemFromBasket(basket, productId, quantity);
            
            //return NoContent();
        }
    }
}
