using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recipes.Application.Common.Mappings;
using Recipes.Domain;

namespace Recipes.Application.Models.Queries.GetModelList
{
    public class RecipeListVm
    {
        public IList<RecipeLookupDto> Recipes { get; set; }
    }
}
