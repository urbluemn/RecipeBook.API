using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Recipes.Application.Common.Mappings;
using Recipes.Application.Interfaces;
using Recipes.Persistence;

namespace Recipes.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public readonly RecipeDbContext Context;
        public readonly IMapper Mapper;

        public QueryTestFixture()
        {
            Context = RecipesContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(
                    new AssemblyMappingProfile(typeof(IRecipeDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            RecipesContextFactory.Destroy(Context);
        }
    }
}