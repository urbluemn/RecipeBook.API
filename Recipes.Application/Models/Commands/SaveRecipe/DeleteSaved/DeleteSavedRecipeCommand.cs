using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Recipes.Application.Models.Commands.SaveRecipe.DeleteSaved
{
    public class DeleteSavedRecipeCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid RecipeId { get; set; }
    }
}