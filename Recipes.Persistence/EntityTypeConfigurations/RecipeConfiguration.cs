using Recipes.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Persistence.EntityTypeConfigurations
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasKey(recipe => recipe.Id);
            builder.HasIndex(recipe => recipe.Id).IsUnique();
            builder.Property(recipe => recipe.Name).HasMaxLength(50).IsRequired();
            builder.Property(recipe => recipe.Description).HasMaxLength(250).IsRequired();
            builder.Property(recipe => recipe.Details).HasMaxLength(1000).IsRequired();
        }
    }
}
