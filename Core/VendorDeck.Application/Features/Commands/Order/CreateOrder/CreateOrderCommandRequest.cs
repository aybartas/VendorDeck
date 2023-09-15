﻿using MediatR;
using VendorDeck.Application.Dtos;

namespace VendorDeck.Application.Features.Commands.Order.CreateOrder
{
    public class CreatePaymentIntentCommandRequest : IRequest<CreatePaymentIntentCommandResponse>
    {
        public OrderDto Order { get; set; }
    }
}