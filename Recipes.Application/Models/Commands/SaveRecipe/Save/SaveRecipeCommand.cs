using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Recipes.Application.Models.Commands.SaveRecipe.Save
{
    public class SaveRecipeCommand : IRequest
    {
        public Guid OperationId { get; set; }
        public Guid UserId { get; set; }
        public Guid RecipeId { get; set; }
    }
}