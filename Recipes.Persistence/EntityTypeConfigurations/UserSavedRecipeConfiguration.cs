using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipes.Domain;

namespace Recipes.Persistence.EntityTypeConfigurations
{
    public class UserSavedRecipeConfiguration : IEntityTypeConfiguration<UserSavedRecipe>
    {
        public void Configure(EntityTypeBuilder<UserSavedRecipe> builder)
        {
            builder.HasKey(savedRecipe => savedRecipe.OperationId);
            builder.HasIndex(savedRecipe => savedRecipe.UserId);
            builder.HasIndex(savedRecipe => savedRecipe.RecipeId);
            builder.Property(savedRecipe => savedRecipe.UserId).IsRequired();
            builder.Property(savedRecipe => savedRecipe.RecipeId).IsRequired();
        }
    }
}