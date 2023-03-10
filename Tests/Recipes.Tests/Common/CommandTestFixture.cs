using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recipes.Persistence;

namespace Recipes.Tests.Common
{
    public /*abstract*/ class CommandTestFixture : IDisposable
    {
        //protected readonly RecipeDbContext Context;
        public readonly RecipeDbContext Context;

        /*protected*/public CommandTestFixture(){
            Context = RecipesContextFactory.Create();
        }

        public void Dispose()
        {
            RecipesContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("CommandCollection")]
    public class CommandCollection : ICollectionFixture<CommandTestFixture> { }
}