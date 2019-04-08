using Angular7NetCoreStore.Application;
using Angular7NetCoreStore.Application.Interfaces;
using Angular7NetCoreStore.Domain.Interfaces;
using Angular7NetCoreStore.Infra.Data.Context;
using Angular7NetCoreStore.Infra.Data.Repositories;
using Angular7NetCoreStore.Infra.Data.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace Angular7NetCoreStore.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<ICustomerAppService, CustomerAppService>();

            // Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<Angular7NetCoreStoreContext>();
        }
    }
}
