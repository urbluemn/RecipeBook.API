using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Recipes.Application.Models.Queries.GetModelList
{
    /// <summary>
    /// Request for all recipes
    /// </summary>
    public class GetAllRecipeListQuery : IRequest<RecipeListVm>
    {
    }
}