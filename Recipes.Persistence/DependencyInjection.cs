
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
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<IRecipeDbContext, RecipeDbContext>(opts =>
            {
                opts.UseSqlite(connectionString);
            });
            services.AddScoped<IRecipeDbContext>(provider => provider.GetService<RecipeDbContext>());//,RecipeDbContext>();
            return services;
        }
    }
}
