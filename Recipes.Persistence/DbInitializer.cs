using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(RecipeDbContext context)
        {
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
