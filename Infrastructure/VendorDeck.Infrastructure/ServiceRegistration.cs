using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
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
        }
    }
}
