using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Recipes.Application.Models.Queries.GetModelList;

namespace Recipes.Application.Models.Queries.GetUserSavedRecipes
{
    public class GetUserSavedRecipesQuery : IRequest<RecipeListVm>
    {
        public Guid UserId { get; set; }
    }
}