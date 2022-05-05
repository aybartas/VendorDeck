using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using VendorDeck.Business.Interfaces;
using VendorDeck.Entities.Concrete;

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

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            var buyerId = Request.Cookies["buyerId"];

            if (buyerId == null)
            {
                return NotFound();
            }

            var basket = await basketService.GetBasketWithBasketItems(buyerId);

            if (basket == null) return NotFound();

            return Ok(basket);
        }

        [HttpPost]
        public async Task<IActionResult> AddBasket(int productId,int quantity)
        {
            var product = await productService.FindByIdAsync(productId);

            if (product == null) 
                return NotFound();

            var buyerId = Request.Cookies["buyerId"];
            var basket = await basketService.GetBasketWithBasketItems(buyerId);
            
            if(basket != null)
            {
                basketService.AddItemToBasket(basket, product, quantity);
                return Created("", basket);
            }

            buyerId = Guid.NewGuid().ToString();
            var cookieOptions = new CookieOptions {
                IsEssential = true,
                Expires = DateTime.Now.AddDays(30),
            };

            Response.Cookies.Append("buyerId", buyerId, cookieOptions);
            await basketService.AddAsync(new Basket { BuyerId = buyerId });
            
            basketService.AddItemToBasket(basketService.GetBasketWithBasketItems(buyerId).Result, product, quantity);

            return Created("", basket);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBasket(int productId, int quantity)
        {
            // get basket
            // remove item or reduce quantity
            // save
            return Ok();
        }
    }
}
