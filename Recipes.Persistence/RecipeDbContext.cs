using Microsoft.EntityFrameworkCore;
using Recipes.Application.Interfaces;
using Recipes.Domain;
using Recipes.Persistence.EntityTypeConfigurations;

namespace Recipes.Persistence
{
    public class RecipeDbContext : DbContext, IRecipeDbContext
    {
        public DbSet<Recipe> Recipes { get; set; }

        public RecipeDbContext(DbContextOptions<RecipeDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RecipeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
