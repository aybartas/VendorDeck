﻿using VendorDeck.Application.Dtos;
using VendorDeck.Application.ViewModels;
using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.Application.Abstractions.Services
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(OrderDto orderDto);
    }
}
