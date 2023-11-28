using AutoMapper;
using MediatR;
using VendorDeck.Application.Abstractions.Services;
using VendorDeck.Application.Repositories;
using VendorDeck.Application.ViewModels;
using ProductEntity = VendorDeck.Domain.Entities.Concrete.Product;

namespace VendorDeck.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {

        private readonly IWriteRepository<ProductEntity> _productWriteRepository;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        public CreateProductCommandHandler(IWriteRepository<ProductEntity> productWriteRepository, IMapper mapper, IImageService imageService)
        {
            _productWriteRepository = productWriteRepository;
            _mapper = mapper;
            _imageService = imageService;
        }
        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var result = new CreateProductCommandResponse() { IsSuccess = true };

            var imageResult = await _imageService.UploadImage(request.Product.ImageFile);

            if (!imageResult.IsSuccess)
            {
                result.IsSuccess = false;
                result.ErrorMessage = imageResult.Error;
                return result;
            }

            var product = _mapper.Map<ProductEntity>(request.Product);

            product.ImageUrl = imageResult.Url.ToString();

            await _productWriteRepository.AddAsync(product);
            await _productWriteRepository.SaveAsync();

            var productViewModel = _mapper.Map<ProductViewModel>(product);

            result.Product = productViewModel;

            return result;

        }
    }
}
