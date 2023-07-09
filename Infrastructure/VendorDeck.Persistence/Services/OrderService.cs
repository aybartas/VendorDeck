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

        public OrderService(IWriteRepository<Order> writeRepository, IBasketReadRepository basketReadRepository, IBasketWriteRepository basketWriteRepository,
            IWriteRepository<Address> addressWriteRepository, IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository)
        {
            _basketReadRepository = basketReadRepository;
            _basketWriteRepository = basketWriteRepository;
            _addressWriteRepository = addressWriteRepository;
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
        }
        public async Task<Order> CreateOrder(OrderDto orderDto)
        {
            var basket = await _basketReadRepository.GetSingleAsync(I => I.BuyerId == orderDto.BuyerId);

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
                    Country = "",
                    City = "",
                    State = "",
                    Address1 = "",
                    Address2 = "",
                };

                await _addressWriteRepository.AddAsync(address);
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

            var createdOrder =  await _orderWriteRepository.AddAsync(order);

            // Remove existing basket

            await _basketWriteRepository.RemoveAsync(basket.Id);

            return createdOrder;
        }
    }
}
