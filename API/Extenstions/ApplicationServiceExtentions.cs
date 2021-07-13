using API.Data;
using API.interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extenstions
{
    public static class ApplicationServiceExtentions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenServiceImpl>(); // for the lifetime of the request
            services.AddDbContext<DataContext>(options =>
            {
                options.UseMySql(config.GetConnectionString("DefaultConnection"),ServerVersion.AutoDetect(config.GetConnectionString("DefaultConnection")));
            });

            return services;
        }
    }
}