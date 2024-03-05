using DataAccess.EFCore.Models;
using Microsoft.EntityFrameworkCore;
using OrdersAPI.Services;

namespace OrdersAPI.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,IConfiguration config)
        {

            services.AddDistributedMemoryCache();
            services.AddCors(option =>
            {
                option.AddDefaultPolicy(policy => { policy.WithOrigins("http://localhost:4200"); });
            });
            services.AddScoped<IOrderService,OrderService>();
            services.AddDbContext<MN_PSCContext>(options =>
            options.UseSqlServer(config.GetConnectionString("MM_Connection"), b => b.MigrationsAssembly(typeof(MN_PSCContext).Assembly.FullName)));
            return services;
        }
    }
}
