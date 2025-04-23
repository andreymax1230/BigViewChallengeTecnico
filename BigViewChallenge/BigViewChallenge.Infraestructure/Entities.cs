using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BigViewChallenge.Infraestructure.Configuration;
using System.Reflection;
using System.Text.RegularExpressions;

namespace BigViewChallenge.Infraestructure;

/// <summary>
/// Config entities context DB
/// </summary>
public partial class Entities : IdentityDbContext
{
    #region Ctor
    private readonly IHttpContextAccessor _contextAccessor;
    public Entities()
    {
    }

    public Entities(DbContextOptions<Entities> options, IHttpContextAccessor contextAccessor = null) : base(options)
    {
        _contextAccessor = contextAccessor;
    }

    #endregion

    #region Utilities

    /// <summary>
    /// Further configuration the model
    /// </summary>
    /// <param name="builder">The builder being used to construct the model for this context</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        var implementedConfigTypes = Assembly.GetExecutingAssembly()
            .GetTypes().Where(t => !t.IsAbstract
            && !t.IsGenericTypeDefinition
            && t.GetTypeInfo().ImplementedInterfaces.Any(i =>
            i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));

        if (implementedConfigTypes.Any())
            foreach (var configType in implementedConfigTypes)
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                dynamic config = Activator.CreateInstance(configType);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                builder.ApplyConfiguration(config);
            }
        base.OnModelCreating(builder);
    }

    public virtual void ExecuteScriptFile()
    {
        var directory = new DirectoryInfo($"{Directory.GetCurrentDirectory()}\\AppData\\ScriptSQL");
        var files = directory.GetFiles("*.sql");
        foreach (var file in files)
        {
            var script = File.ReadAllText(file.FullName);
            if (!string.IsNullOrEmpty(script))
            {
                string[] commands = Regex.Split(script, @"\bGO\b");
                foreach (var command in commands)
                {
                    if (!string.IsNullOrEmpty(command))
                        Database.ExecuteSqlRaw(command);
                }
            }

        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Creates a DbSet that can be used to query and save instances of entity
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <returns>A set for the given entity type</returns>
    public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : class
    {
        return base.Set<TEntity>();
    }

    #endregion
}