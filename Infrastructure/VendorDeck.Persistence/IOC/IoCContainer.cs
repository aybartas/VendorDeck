

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VendorDeck.Application.Repositories;
using VendorDeck.Domain.Entities.Concrete;
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
            services.AddIdentity<AppUser, AppRole>(
                opt => {
                    opt.Password.RequiredLength = 3;
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequireDigit = false;
                    opt.Password.RequireLowercase = false;
                    opt.Password.RequireUppercase = false;

                }
            ).AddEntityFrameworkStores<VendorDeckContext>();
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            services.AddScoped<IBasketReadRepository, BasketReadRepository>();
            services.AddScoped<IBasketWriteRepository, BasketWriteRepository>();

            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

            services.AddScoped<IOrderReadRepository, OrderReadRepository>();

        }
    }
}
