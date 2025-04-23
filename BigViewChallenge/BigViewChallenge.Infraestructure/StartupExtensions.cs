using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace BigViewChallenge.Infraestructure;

/// <summary>
/// Generate pending migration for DataBase
/// </summary>
public static class StartupExtensions
{
    public static IApplicationBuilder InitializeBD(this IApplicationBuilder builder)
    {
        InitializData(builder.ApplicationServices);
        return builder;
    }

    private static void InitializData(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<Entities>();
        var existDB = context.Database.GetService<IRelationalDatabaseCreator>().Exists();
        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
            if (!existDB)
                context.ExecuteScriptFile();
        }
    }
}