using AutoMapper;
using Microsoft.Extensions.Configuration;
using Stripe;
using VendorDeck.Application.Abstractions.Services;
using VendorDeck.Application.Dtos;
using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.Infrastructure.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration config;

        public PaymentService(IConfiguration config)
        {
            this.config = config;
        }

        public async Task<PaymentIntentDto> SavePayment(Basket basket)
        {
            StripeConfiguration.ApiKey = config["StripeSettings:SecretKey"];

            var service = new PaymentIntentService();
            var subTotal = basket.BasketItems.Sum(x => x.Quantity * x.Product.Price);
            var deliveryFee = subTotal > 100 ? 0 : 5; //////// TO DOO make that calculations using another service or extension method

            PaymentIntent intent;
            var isNew = string.IsNullOrEmpty(basket.PaymentIntentId);

            if(isNew) {

                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long?)(subTotal + deliveryFee),
                    Currency = "usd",
                    PaymentMethodTypes = new List<string>() { "card"}
                };

                intent = await service.CreateAsync(options);

            }
            else
            {
                var options = new PaymentIntentUpdateOptions
                {
                    Amount = (long?)(subTotal + deliveryFee),
                };

                intent = await service.UpdateAsync(basket.PaymentIntentId,options);
            }

            var isSuccess = intent.StripeResponse.StatusCode == System.Net.HttpStatusCode.OK || intent.StripeResponse.StatusCode == System.Net.HttpStatusCode.Created;

            var response = new PaymentIntentDto
            {
                PaymentIntentId = intent.Id,
                ClientSecret = intent.ClientSecret,
                Successs = isSuccess
            };

            return response;
        }
    }
}
