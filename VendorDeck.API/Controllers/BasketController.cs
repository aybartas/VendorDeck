using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VendorDeck.Business.Interfaces;

namespace VendorDeck.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService basketService;
        public BasketController(IBasketService basketService)
        {
            this.basketService = basketService;
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
            // get basket
            // create basket
            // get product
            // add item
            // save

             return Ok();
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
