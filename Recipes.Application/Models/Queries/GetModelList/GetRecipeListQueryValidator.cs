using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Recipes.Application.Models.Queries.GetModelList
{
    public class GetRecipeListQueryValidator : AbstractValidator<GetRecipeListQuery>
    {
        public GetRecipeListQueryValidator()
        {
            RuleFor(getRecipelistDetails =>
                getRecipelistDetails.UserId).NotEqual(Guid.Empty);
        }
    }
}
