using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Recipes.Domain;

namespace Recipes.Application.Models.Commands.SaveRecipe.DeleteSaved
{
    public class DeleteSavedRecipeCommandValidator : AbstractValidator<DeleteSavedRecipeCommand>
    {
        public DeleteSavedRecipeCommandValidator()
        {
            RuleFor(savedRecipe =>
                savedRecipe.UserId).NotEqual(Guid.Empty);
            RuleFor(savedRecipe =>
                savedRecipe.RecipeId).NotEqual(Guid.Empty);
        }
    }
}