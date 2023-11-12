using AutoMapper;
using MediatR;
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

        private readonly IMapper _mapper;
        public UpdateProductCommandHandler(IWriteRepository<ProductEntity> productWriteRepository, IMapper mapper, IReadRepository<ProductEntity> productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _mapper = mapper;
            _productReadRepository = productReadRepository;
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

            _mapper.Map(request.Product, existingProduct);

            await _productWriteRepository.SaveAsync();

            return response;
        }
    }
}
