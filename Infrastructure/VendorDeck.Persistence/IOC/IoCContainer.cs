

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VendorDeck.Application.Services;
using VendorDeck.Persistence.Concretes;
using VendorDeck.Persistence.Context;

namespace VendorDeck.Persistence.IOC
{
    public static class IoCContainer
    {
        public static void AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionString"];
            services.AddDbContext<VendorDeckContext>(opt => opt.UseSqlServer(connectionString) );
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBasketService, BasketService>();  
        }
    }
}
