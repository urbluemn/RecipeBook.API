using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Recipes.Application.Models.Queries.GetModelDetails
{
    public class GetRecipeDetailsQueryValidator : AbstractValidator<GetRecipeDetailsQuery>
    {
        public GetRecipeDetailsQueryValidator()
        {
            RuleFor(getRecipeDetails =>
                getRecipeDetails.Id).NotEqual(Guid.Empty);
        }
    }
}