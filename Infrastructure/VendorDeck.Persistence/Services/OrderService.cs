using Microsoft.AspNetCore.Identity;
using System.Runtime.InteropServices;
using VendorDeck.Application.Abstractions.Services;
using VendorDeck.Application.Dtos;
using VendorDeck.Application.Exceptions;
using VendorDeck.Application.Repositories;
using VendorDeck.Domain.Entities.Concrete;
using VendorDeck.Domain.Enums;

namespace VendorDeck.Persistence.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IBasketReadRepository _basketReadRepository;
        private readonly IBasketWriteRepository _basketWriteRepository;
        private readonly IWriteRepository<Address> _addressWriteRepository;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly UserManager<AppUser> _userManager;


        public OrderService(IBasketReadRepository basketReadRepository, IBasketWriteRepository basketWriteRepository,
            IWriteRepository<Address> addressWriteRepository,
            IOrderWriteRepository orderWriteRepository, UserManager<AppUser> userManager)
        {
            _basketReadRepository = basketReadRepository;
            _basketWriteRepository = basketWriteRepository;
            _addressWriteRepository = addressWriteRepository;
            _orderWriteRepository = orderWriteRepository;
            _userManager = userManager;
        }
        public async Task<Order> CreateOrder(OrderDto orderDto)
        {
            var user = await _userManager.FindByNameAsync(orderDto.BuyerId);
            if (user is null)
                throw new UserNotFoundException();

            var basket = await _basketReadRepository.GetSingleAsync(I => I.BuyerId == orderDto.BuyerId);

            if (basket is null)
                throw new BasketNotFoundException(orderDto.BuyerId);


            var items = new List<OrderItem>();
            foreach (var basketItem in basket.BasketItems)
            {
                var product = await _productReadRepository.GetSingleAsync(I => I.Id == basketItem.ProductId);

                var orderItem = new OrderItem
                {
                    OrderedProductItem = new OrderedProductItem
                    {
                        Name = basketItem.Product.Name,
                        ProductId = basketItem.ProductId,
                        PictureUrl = basketItem.Product.ImageUrl
                    },
                    Price = basketItem.Product.Price,
                    Quantity = basketItem.Quantity,
                };

                if (product.Stock < basketItem.Quantity)
                    throw new InsufficientNumberOfStocksException(product.Id, basketItem.Quantity);

                product.Stock -= basketItem.Quantity;
                _productWriteRepository.Update(product);

                items.Add(orderItem);
            }

            // Create addres if saved
            if (orderDto.SaveAddress)
            {
                var address = new Address
                {
                    UserId = user.Id,
                    Country = orderDto.ShippingAddress.Country,
                    City = orderDto.ShippingAddress.City,
                    State = orderDto.ShippingAddress.State,
                    Details = orderDto.ShippingAddress.Details,
                };

                await _addressWriteRepository.AddAsync(address);
                await _addressWriteRepository.SaveAsync();
            }

            var subTotal = items.Sum(I => I.Price);
            var deliveryFee = orderDto.DeliveryFee;

            var order = new Order
            {
                BuyerId = orderDto.BuyerId,
                OrderDate = DateTime.UtcNow,
                OrderItems = items,
                SubTotal = subTotal,
                DeliveryFee = deliveryFee,
                Total = subTotal + deliveryFee,
                OrderStatus = OrderStatus.Pending,
                ShippingAddress = orderDto.ShippingAddress
            };

            var createdOrder = await _orderWriteRepository.AddAsync(order);
            await _orderWriteRepository.SaveAsync();

            // Remove existing basket

            await _basketWriteRepository.RemoveAsync(basket.Id);
            await _basketWriteRepository.SaveAsync();

            return createdOrder;
        }
    }
}
