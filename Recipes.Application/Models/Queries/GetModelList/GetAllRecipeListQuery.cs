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
        // public int pageSize { get; set; }
        // public int pageNumber { get; set; }

        // public GetAllRecipeListQuery(int pageNumber, int pageSize)
        // {
        //     this.pageNumber = pageNumber;
        //     this.pageSize = pageSize;
        // }
    }
}