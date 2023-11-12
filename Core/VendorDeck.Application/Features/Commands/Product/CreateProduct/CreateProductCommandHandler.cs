using AutoMapper;
using MediatR;
using VendorDeck.Application.Repositories;
using ProductEntity = VendorDeck.Domain.Entities.Concrete.Product;

namespace VendorDeck.Application.Features.Commands.Product.CreateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, UpdateProductCommandResponse>
    {

        private readonly IWriteRepository<ProductEntity> _productWriteRepository;
        private readonly IMapper _mapper;
        public UpdateProductCommandHandler(IWriteRepository<ProductEntity> productWriteRepository, IMapper mapper)
        {
            _productWriteRepository = productWriteRepository;
            _mapper = mapper;
        }
        public async Task<UpdateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<ProductEntity>(request.Product);

            await _productWriteRepository.AddAsync(product);

            await _productWriteRepository.SaveAsync();

            return new() { IsSuccess = true };

        }
    }
}
