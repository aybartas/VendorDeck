using AutoMapper;
using MediatR;
using VendorDeck.Application.Abstractions.Services;
using VendorDeck.Application.Features.Commands.Product.CreateProduct;
using VendorDeck.Application.Features.Commands.Product.DeleteProduct;
using VendorDeck.Application.Repositories;
using ProductEntity = VendorDeck.Domain.Entities.Concrete.Product;

namespace VendorDeck.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {

        private readonly IWriteRepository<ProductEntity> _productWriteRepository;
        private readonly IReadRepository<ProductEntity> _productReadRepository;
        private readonly IImageService _imageService;

        private readonly IMapper _mapper;
        public UpdateProductCommandHandler(IWriteRepository<ProductEntity> productWriteRepository, IMapper mapper, IReadRepository<ProductEntity> productReadRepository, IImageService imageService)
        {
            _productWriteRepository = productWriteRepository;
            _mapper = mapper;
            _productReadRepository = productReadRepository;
            _imageService = imageService;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateProductCommandResponse() { IsSuccess = true };

            var existingProduct = await _productReadRepository.GetSingleAsync(x => x.Id == request.Product.Id);

            if (existingProduct is null)
            {
                response.IsSuccess = false;
                response.ErrorMessage = "Product not exist";
                return response;
            }

            if(request.Product.File != null)
            {
                var imageResult = await _imageService.UploadImage(request.Product.File);

                if (!imageResult.IsSuccess)
                {
                    response.IsSuccess = false;
                    response.ErrorMessage = imageResult.Error;
                    return response;
                }

                var legacyImageId = existingProduct.PublicId;

                if (!string.IsNullOrEmpty(legacyImageId))
                {
                    var legacyImage = await _imageService.DeleteImage(legacyImageId);

                    if (!legacyImage)
                    {
                        response.IsSuccess = false;
                        response.ErrorMessage = "Error removing legacy image";
                        return response;
                    }
                }

                existingProduct.ImageUrl = imageResult.Url.ToString();
                existingProduct.PublicId = imageResult.PublicId;

            }

            _mapper.Map(request.Product, existingProduct);

            await _productWriteRepository.SaveAsync();

            return response;
        }
    }
}
