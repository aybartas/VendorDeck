using Microsoft.AspNetCore.Identity;
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
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly UserManager<AppUser> _userManager;

        public OrderService(IWriteRepository<Order> writeRepository, IBasketReadRepository basketReadRepository, IBasketWriteRepository basketWriteRepository,
            IWriteRepository<Address> addressWriteRepository, IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository, UserManager<AppUser> userManager)
        {
            _basketReadRepository = basketReadRepository;
            _basketWriteRepository = basketWriteRepository;
            _addressWriteRepository = addressWriteRepository;
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _userManager = userManager;
        }
        public async Task<Order> CreateOrder(OrderDto orderDto)
        {
            var basket = await _basketReadRepository.GetSingleAsync(I => I.BuyerId == orderDto.BuyerId);

            var user = await _userManager.FindByNameAsync(orderDto.BuyerId);

            if (basket is null)
                throw new BasketNotFoundException(orderDto.BuyerId);

            var items = new List<OrderItem>();

            foreach (var basketItem in basket.BasketItems)
            {
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
                items.Add(orderItem);
            }

            // Create addres if saved
            if (orderDto.SaveAddress)
            {

                var address = new Address
                {
                    FullName = orderDto.ShippingAddress?.FullName,
                    Country = orderDto.ShippingAddress?.Country,
                    City = orderDto.ShippingAddress?.City,
                    State = orderDto.ShippingAddress?.State,
                    Zip = orderDto.ShippingAddress?.Zip,
                    Address1 = orderDto.ShippingAddress?.Address1,
                    Address2 = orderDto.ShippingAddress?.Address2,
                    AppUserId = user.Id
                };

                await _addressWriteRepository.AddAsync(address);
                await _addressWriteRepository.SaveAsync();

            }

            var subTotal = items.Sum(I => I.Price);
            var deliveryFee = orderDto.DeliveryFee;
            var maxOrderNumber = await _orderReadRepository.GetMaxOrderNumber();

            var order = new Order
            {
                BuyerId = orderDto.BuyerId,
                OrderDate = DateTime.UtcNow,
                OrderItems = items,
                SubTotal = subTotal,
                DeliveryFee = deliveryFee,
                Total = subTotal + deliveryFee,
                OrderStatus = OrderStatus.Pending,
                ShippingAddress = orderDto.ShippingAddress,
                OrderNumber = maxOrderNumber + 1
            };

            var createdOrder = await _orderWriteRepository.AddAsync(order);
            await _orderWriteRepository.SaveAsync();

            if (createdOrder is not null)
            {
                await _basketWriteRepository.RemoveAsync(basket.Id);
                await _basketWriteRepository.SaveAsync();
            }

            return order;
        }
    }
}
