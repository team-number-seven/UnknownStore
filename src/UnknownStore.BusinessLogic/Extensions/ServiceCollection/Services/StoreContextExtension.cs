using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnknownStore.DAL;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.Extensions.ServiceCollection.Services
{
    public static class StoreContextExtension
    {
        public static IServiceCollection AddStoreContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreDbContext>(opt =>
            {
                opt.UseLazyLoadingProxies().UseNpgsql(configuration.GetConnectionString("StoreDb"));
            }).AddScoped(typeof(IStoreDbContext), typeof(StoreDbContext));
            return services;
        }
    }
}