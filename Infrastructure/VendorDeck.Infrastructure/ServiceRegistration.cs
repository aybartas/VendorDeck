using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Application.Repositories;
using VendorDeck.Application.Token;
using VendorDeck.Domain.Entities.Concrete;
using VendorDeck.Infrastructure.Services;

namespace VendorDeck.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<ITokenHandler, TokenHandler>();
        }
    }
}
