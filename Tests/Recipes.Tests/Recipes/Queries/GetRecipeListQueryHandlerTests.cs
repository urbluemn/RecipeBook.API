using System;
using Shouldly;
using AutoMapper;
using Recipes.Application.Models.Queries.GetModelList;
using Recipes.Persistence;
using Recipes.Tests.Common;

namespace Recipes.Tests.Recipes.Queries
{
    [Collection("QueryCollection")]
    public class GetRecipeListQueryHandlerTests
    {
        private readonly RecipeDbContext _context;
        private readonly IMapper _mapper;

        public GetRecipeListQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetRecipeListQueryHandler_Success()
        {
            //Arrange
            var handler = new GetRecipeListQueryHandler(_context, _mapper);

            //Act
            var result = await handler.Handle(
                new GetRecipeListQuery
                {
                    UserId = RecipesContextFactory.UserAId
                },
                CancellationToken.None
            );

            //Assert
            result.ShouldBeOfType<RecipeListVm>();
            result.Recipes.Count.ShouldBe(2);
        }
    }
}