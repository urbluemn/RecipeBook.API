using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Recipes.Application.Models.Queries.GetModelDetails
{
    /// <summary>
    /// Mapped Model Query
    /// </summary>
    public class GetRecipeDetailsQuery : IRequest<RecipeDetailsVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
