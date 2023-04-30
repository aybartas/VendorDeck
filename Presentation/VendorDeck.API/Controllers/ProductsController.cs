using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using VendorDeck.API.ActionFilters;
using VendorDeck.Application.Features.Queries.Product.GetAllProduct;
using VendorDeck.Application.Features.Queries.Product.GetProduct;
using VendorDeck.Application.Features.Queries.Product.GetProductFilterValues;
using VendorDeck.Application.Repositories;
using VendorDeck.Application.RequestParameters;
using VendorDeck.Application.Responses;

namespace VendorDeck.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]GetAllProductQueryRequest getAllProductQueryRequest)
        {
            var response = await _mediator.Send(getAllProductQueryRequest);

            return Ok(response); 
        }

        [HttpGet("{id}")]
        [ValidModelState]
        public async Task<IActionResult> GetProduct(int id)
        {
            var getProductRequest = new GetProductQueryRequest { ProductId= id };
            var product = await _mediator.Send(getProductRequest);
            return product is null ? NotFound("Product not found") : Ok(product);
        }
        [HttpGet("filters")]
        [ValidModelState]
        public async Task<IActionResult> GetProductFilters(int id)
        {
            var getFilterValuesRequest = new GetProductsFilterValuesRequest();
            var filterValues = await _mediator.Send(getFilterValuesRequest);
            return Ok(filterValues);
        }
    }
}
