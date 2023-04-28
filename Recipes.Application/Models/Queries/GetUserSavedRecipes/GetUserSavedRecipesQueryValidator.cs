using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Recipes.Application.Models.Queries.GetUserSavedRecipes
{
    public class GetUserSavedRecipesQueryValidator : AbstractValidator<GetUserSavedRecipesQuery>
    {
        public GetUserSavedRecipesQueryValidator()
        {
            RuleFor(getUserSavedRecipes =>
                getUserSavedRecipes.UserId).NotEqual(Guid.Empty);
        }
    }
}