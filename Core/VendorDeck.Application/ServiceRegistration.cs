using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace VendorDeck.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(typeof(ServiceRegistration).Assembly);
        }
    }
}
