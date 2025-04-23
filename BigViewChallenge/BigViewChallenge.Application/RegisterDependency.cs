using FluentValidation;
using BigViewChallenge.Application.Common;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BigViewChallenge.Application;

/// <summary>
/// Register Services dependences for Command and Queries
/// </summary>
public static class RegisterDependency
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}