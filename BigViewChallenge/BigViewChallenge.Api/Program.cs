
using BigViewChallenge.Api.Infraestructure;
using BigViewChallenge.Infraestructure;
using Microsoft.EntityFrameworkCore;
using BigViewChallenge.Application;
using BigViewChallenge.Infraestructure.Exception;
using Microsoft.OpenApi.Models;
using BigViewChallenge.Infraestructure.Auth;

namespace BigViewChallenge.Api;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },new string[]{}
        }
        });
            options.EnableAnnotations();
        });
        builder.Services.AddDbContext<Entities>(options =>
        {
            options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("Entities"));
        });
        builder.Services.AddApplication();
        builder.Services.AddCustomServices(builder.Configuration);
        builder.Services.AddCustomCors(builder.Configuration);
        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        builder.Services.AddProblemDetails();

        builder.Services.AddAuthentication(AuthenticationHandlerOptions.DefaultScheme)
        .AddScheme<AuthenticationHandlerOptions, AuthenticationHandler>
        (AuthenticationHandlerOptions.DefaultScheme, options => { });
   

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors("EnableCORS");
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.UseExceptionHandler();
        app.InitializeBD();
        app.Run();

    }
}