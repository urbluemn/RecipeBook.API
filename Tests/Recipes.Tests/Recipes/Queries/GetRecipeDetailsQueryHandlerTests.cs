using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Recipes.Application.Models.Queries.GetModelDetails;
using Recipes.Persistence;
using Recipes.Tests.Common;
using Shouldly;

namespace Recipes.Tests.Recipes.Queries
{
    [Collection("QueryCollection")]
    public class GetRecipeDetailsQueryHandlerTests
    {
        private readonly RecipeDbContext _context;
        private readonly IMapper _mapper;

        public GetRecipeDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetRecipeDetailsQueryHandler_Success()
        {
            //Arrange
            var handler = new GetRecipeDetailsQueryHandler(_context, _mapper);

            //Act
            var result = await handler.Handle(
                new GetRecipeDetailsQuery
                {
                    UserId = RecipesContextFactory.UserBId,
                    Id = Guid.Parse("63EC94EF-8819-4F3B-91FE-BC12EC3ACD44")
                },
                CancellationToken.None
            );

            //Assert
            result.ShouldBeOfType<RecipeDetailsVm>();
            result.Name.ShouldBe("Name2");
            result.Details.ShouldBe("Details2");
            result.Description.ShouldBe("Description2");
        }
    }
}