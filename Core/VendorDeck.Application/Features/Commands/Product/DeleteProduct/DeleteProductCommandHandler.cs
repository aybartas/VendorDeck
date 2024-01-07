using AutoMapper;
using MediatR;
using VendorDeck.Application.Repositories;
using ProductEntity = VendorDeck.Domain.Entities.Concrete.Product;

namespace VendorDeck.Application.Features.Commands.Product.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {

        private readonly IWriteRepository<ProductEntity> _productWriteRepository;
        private readonly IReadRepository<ProductEntity> _productReadRepository;

        public DeleteProductCommandHandler(IWriteRepository<ProductEntity> productWriteRepository, IReadRepository<ProductEntity> productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteProductCommandResponse() { IsSuccess = true };

            var existingProduct = await _productReadRepository.GetSingleAsync(x => x.Id == request.ProductId);

            if (existingProduct is null)
            {
                response.IsSuccess = false;
                response.ErrorMessage = "Product not exist";
                return response;
            }

            await _productWriteRepository.RemoveAsync(request.ProductId);
            await _productWriteRepository.SaveAsync();

            return response;
        }
    }
}
