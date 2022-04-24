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
            var customerId = int.Parse(Request.Cookies["customerId"]);

            var basket = await basketService.GetBasketWithBasketItems(customerId);

            if (basket == null) return NotFound();

            return Ok(basket);
        }

        [HttpPost]
        public async Task<IActionResult> AddBasket(int productId,int quantity)
        {
            var customerId = int.Parse(Request.Cookies["customerId"]);
            var basket = await basketService.GetAsync(I => I.CustomerId == customerId);

            if (basket == null)
            {
                var buyerId = Guid.NewGuid().ToString();
                var cookieOptions = new CookieOptions {
                    IsEssential = true,
                    Expires = DateTime.Now.AddDays(30),
                };

                Response.Cookies.Append("customerId", buyerId, cookieOptions);

                await basketService.AddAsync(new Basket { CustomerId = int.Parse(buyerId) });
            }

            var product = await productService.FindByIdAsync(productId);
            var currentBasket  = basketService.GetAsync(I => I.CustomerId == customerId).Result.First();

            if (product == null) return NotFound();

            basketService.AddItemToBasket(currentBasket, product, quantity);

            return Created("", currentBasket);
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
