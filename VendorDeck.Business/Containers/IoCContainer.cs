using Microsoft.Extensions.DependencyInjection;
using VendorDeck.Business.Concrete;
using VendorDeck.Business.Interfaces;
using VendorDeck.DataAccess.Concrete;
using VendorDeck.DataAccess.Interfaces;

namespace VendorDeck.Business.Containers
{
    public static class IoCContainer
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IBasketRepository, BasketRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();


        }
    }
}
