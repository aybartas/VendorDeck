using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Application.Repositories;

namespace VendorDeck.Application.Features.Commands.Basket.CreateBasket
{
    public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommandRequest, CreateBasketCommandResponse>
    {
        private readonly IBasketWriteRepository _basketWriteRepository;

        public CreateBasketCommandHandler(IBasketWriteRepository basketWriteRepository)
        {
            _basketWriteRepository = basketWriteRepository;
        }

        public async Task<CreateBasketCommandResponse> Handle(CreateBasketCommandRequest request, CancellationToken cancellationToken = default)
        {
            var response = new CreateBasketCommandResponse { Success= true };
            try
            {
                await _basketWriteRepository.AddAsync(request.Basket);
            }
            catch (Exception)
            {
                response.Success= false;
            }
            return response;
        }
    }
}
