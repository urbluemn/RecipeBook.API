using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Recipes.Domain;

namespace Recipes.Application.Models.Commands.SaveRecipe.Save
{
    public class SaveRecipeCommandValidator : AbstractValidator<SaveRecipeCommand>
    {
        public SaveRecipeCommandValidator()
        {
            RuleFor(savedRecipe =>
                savedRecipe.UserId).NotEqual(Guid.Empty);
            RuleFor(savedRecipe =>
                savedRecipe.RecipeId).NotEqual(Guid.Empty);
        }
    }
}