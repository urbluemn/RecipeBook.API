using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Domain
{
    public class UserSavedRecipe
    {
        public Guid OperationId { get; set; }
        public Guid UserId { get; set; }
        public Guid RecipeId { get; set; }
    }
}