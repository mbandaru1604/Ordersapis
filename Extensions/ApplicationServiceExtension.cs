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
            return services;
        }
    }
}
