using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infra.Data.Repository;

using Microsoft.Extensions.DependencyInjection;

namespace Infra.Ioc
{
    public class DependencyContainer
    {
        public void RegisterServices(IServiceCollection services)
        {
            //Application Layer
            services.AddScoped<IProductService, ProductService>( );

            //Infra.Data
            services.AddScoped<IProductRepository, ProductRepository>( );
        }
    }
}
