using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recipes.Application.Interfaces;

namespace Recipes.Persistence
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Configuring Dependency Injection Extension for DB
        /// </summary>
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            //SQLite db
            var connectionString = configuration["DbConnection"];

            //SQLServer db
            //var connectionString = configuration["SqlServerDbConnect"];
            services.AddDbContext<IRecipeDbContext, RecipeDbContext>(opts =>
            {
                opts.UseSqlite(connectionString);
            });
            services.AddScoped<IRecipeDbContext, RecipeDbContext>(/*provider => provider.GetService<RecipeDbContext>()*/);
            return services;
        }
    }
}
