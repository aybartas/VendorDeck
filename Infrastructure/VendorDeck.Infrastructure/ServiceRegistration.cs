using CloudinaryDotNet;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using Stripe;
using VendorDeck.Application.Abstractions.Services;
using VendorDeck.Application.Token;
using VendorDeck.Infrastructure.Services;

namespace VendorDeck.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var redisConnection = configuration["RedisConnectionString"];

            services.AddStackExchangeRedisCache(opt =>
            {
                opt.Configuration = redisConnection;
                opt.InstanceName = "VendorDeck_";
            });
            services.AddScoped<ICacheService, CacheService>();
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IImageService, ImageService>();

            var cloudinaryAccount = new CloudinaryDotNet.Account
            {
                Cloud = configuration["Cloudinary:CloudName"],
                ApiKey = configuration["Cloudinary:APIKey"],
                ApiSecret = configuration["Cloudinary:APISecret"],
            };

            services.AddSingleton(new Cloudinary(cloudinaryAccount)); 
        }
    }
}
