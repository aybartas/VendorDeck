using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VendorDeck.Application.Abstractions.Services;
using VendorDeck.Application.Constants;
using VendorDeck.Application.Dtos;
using VendorDeck.Application.Features.Commands.Product.CreateProduct;
using VendorDeck.Application.Features.Commands.Product.DeleteProduct;
using VendorDeck.Application.Features.Commands.Product.UpdateProduct;
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
        //private readonly ICacheService _cacheService;

        public ProductsController(IMediator mediator, ICacheService cacheService)
        {
            _mediator = mediator;
            //_cacheService = cacheService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        {
            //var cachedProducts = await _cacheService.GetData<GetAllProductQueryResponse>(DistributedCacheKeys.AllProductsResponse);
            //if (cachedProducts != null) return Ok(cachedProducts);

            var response = await _mediator.Send(getAllProductQueryRequest);

            //if (response?.TotalCount > 0)
            //    await _cacheService.SetData(DistributedCacheKeys.AllProductsResponse, response);

            return Ok(response);
        }

        [HttpGet("{id}",Name = "GetProduct")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var getProductRequest = new GetProductQueryRequest { ProductId = id };
            var product = await _mediator.Send(getProductRequest);
            return product is null ? NotFound("Product not found") : Ok(product);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDto product)
        {
            var requst = new CreateProductCommandRequest { Product=product};
            var response = await _mediator.Send(requst);
            return CreatedAtRoute("GetProduct", new { Id = response.ProductId}, product);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductDto product)
        {
            var requst = new UpdateProductCommandRequest { Product = product };
            var response = await _mediator.Send(requst);
            return response.IsSuccess ? NoContent() : BadRequest(new ProblemDetails { Title = "Error updating product",Detail = response.ErrorMessage});
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var requst = new DeleteProductCommandRequest { ProductId = productId };
            var response = await _mediator.Send(requst);
            return response.IsSuccess ? NoContent() : BadRequest(new ProblemDetails { Title = "Error updating product", Detail = response.ErrorMessage });
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
