using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VendorDeck.API.ActionFilters;
using VendorDeck.Business.Interfaces;
using VendorDeck.Entities.Concrete;

namespace VendorDeck.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductsController(IProductService productService)
        {
            this.productService = productService;   
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productEntities = await productService.GetAllAsync();
            return Ok(productEntities);
        }

        [HttpGet("{id}")]
        [ValidModelState]
        [ServiceFilter(typeof(ValidId<Product>))]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await productService.FindByIdAsync(id);
            return Ok(product);

        }

    }
}
