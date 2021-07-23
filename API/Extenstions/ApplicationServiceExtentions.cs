using API.Data;
using API.Helpers;
using API.interfaces;
using API.Interfaces;
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
            services.AddScoped<IUserRepository, UserRepositoryImpl>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DataContext>(options =>
            {
                options.UseMySql(config.GetConnectionString("DefaultConnection"),ServerVersion.AutoDetect(config.GetConnectionString("DefaultConnection")));
            });

            return services;
        }
    }
}