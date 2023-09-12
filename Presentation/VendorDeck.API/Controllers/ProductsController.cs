using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VendorDeck.Application.Abstractions.Services;
using VendorDeck.Application.Constants;
using VendorDeck.Application.Features.Queries.Product.GetAllProduct;
using VendorDeck.Application.Features.Queries.Product.GetProduct;
using VendorDeck.Application.Features.Queries.Product.GetProductFilterValues;

namespace VendorDeck.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICacheService _cacheService;

        public ProductsController(IMediator mediator, ICacheService cacheService)
        {
            _mediator = mediator;
            _cacheService = cacheService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        {
            var cachedProducts = await _cacheService.GetData<GetAllProductQueryResponse>(DistributedCacheKeys.AllProductsResponse);

            if (cachedProducts != null) return Ok(cachedProducts);

            var response = await _mediator.Send(getAllProductQueryRequest);

            if (response?.TotalCount > 0)
                await _cacheService.SetData(DistributedCacheKeys.AllProductsResponse, response);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var getProductRequest = new GetProductQueryRequest { ProductId = id };
            var product = await _mediator.Send(getProductRequest);
            return product is null ? NotFound("Product not found") : Ok(product);
        }
        [HttpGet("filters")]
        public async Task<IActionResult> GetProductFilters()
        {
            var getFilterValuesRequest = new GetProductsFilterValuesRequest();
            var filterValues = await _mediator.Send(getFilterValuesRequest);
            return Ok(filterValues);
        }
    }
}
