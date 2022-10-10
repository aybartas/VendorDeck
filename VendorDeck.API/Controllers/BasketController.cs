using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using VendorDeck.Business.Interfaces;
using VendorDeck.DataAccess.Interfaces;
using VendorDeck.Entities.Concrete;
using VendorDeck.Entities.Dtos;

namespace VendorDeck.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService basketService;
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public BasketController(IBasketService basketService, IProductService productService, IMapper mapper)
        {
            this.basketService = basketService;
            this.productService = productService;
            this.mapper = mapper;
        }

        [HttpGet(Name = "GetBasket")]
        public async Task<IActionResult> GetBasket()
        {
            var buyerId = Request.Cookies["buyerId"];

            var basket = await basketService.GetBasketWithBasketItems(buyerId);

            if (basket == null || buyerId == null)
            {
                return NotFound();
            }

            var basketDto = mapper.Map<BasketDto>(basket);

            return Ok(basketDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddBasket( [FromBody]AddBasketDto basketItem)
        {
            var product = await productService.FindByIdAsync(basketItem.ProductId);

            if (product == null) 
                return NotFound();

            var buyerId = Request.Cookies["buyerId"];
            var basket = await basketService.GetBasketWithBasketItems(buyerId);
            
            if(basket != null)
            {
                basketService.AddItemToBasket(basket, product, basketItem.Quantity);
                return Created("", mapper.Map<BasketDto>(basket));
            }
            
            buyerId = Guid.NewGuid().ToString();
            var cookieOptions = new CookieOptions {
                IsEssential = true,
                Expires = DateTime.Now.AddDays(30),
            };

            Response.Cookies.Append("buyerId", buyerId, cookieOptions);

            // create new basket 

            var newBasket = new Basket
            {
                BuyerId = buyerId,
                BasketItems = { new BasketItem { Quantity = basketItem.Quantity, ProductId = basketItem.ProductId} }
            };

            await basketService.AddAsync(newBasket);

            return CreatedAtRoute("GetBasket", mapper.Map<BasketDto>(newBasket));
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBasketItem(int productId, int quantity)
        {
            // get basket
            var buyerId = Request.Cookies["buyerId"];

            var basket = await basketService.GetBasketWithBasketItems(buyerId);

            if (basket == null || buyerId == null)
            {
                return NotFound();
            }

            basketService.RemoveItemFromBasket(basket, productId, quantity);
            
            // save
            return NoContent();
        }
    }
}
