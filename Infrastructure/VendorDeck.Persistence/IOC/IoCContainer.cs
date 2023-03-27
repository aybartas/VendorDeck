

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VendorDeck.Application.Repositories;

using VendorDeck.Persistence.Context;
using VendorDeck.Persistence.Repositories;

namespace VendorDeck.Persistence.IOC
{
    public static class IoCContainer
    {
        public static void AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionString"];
            services.AddDbContext<VendorDeckContext>(opt => opt.UseSqlServer(connectionString));
            
            services.AddScoped<IBasketReadRepository, BasketReadRepository>();
            services.AddScoped<IBasketWriteRepository, BasketWriteRepository>();

            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

        }
    }
}
