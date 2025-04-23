using BigViewChallenge.Domain.Repositories;
using BigViewChallenge.Domain.UnitOfWork;
using BigViewChallenge.Infraestructure;
using BigViewChallenge.Infraestructure.SettingsConfig;

namespace BigViewChallenge.Api.Infraestructure;

public static class RegisterDependency
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
    {
        var config = configuration.GetSection("Auth");
        var setting = config.Get<OAuthConfig>();
        services.Configure<OAuthConfig>(config);
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        return services;
    }

    public static IServiceCollection AddCustomCors(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("EnableCORS", builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
        });
        return services;
    }
}