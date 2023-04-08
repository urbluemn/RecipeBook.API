using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Recipes.Application.Models.Queries.GetModelList;
using Recipes.Persistence;
using Recipes.Tests.Common;
using Shouldly;

namespace Recipes.Tests.Recipes.Queries
{
    [Collection("QueryCollection")]
    public class GetAllRecipeListQueryHandlerTests
    {
        private readonly RecipeDbContext _context;
        private readonly IMapper _mapper;

        public GetAllRecipeListQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetAllRecipeListQueryHandler_Success()
        {
            //Arrange
            var handler = new GetAllRecipeListQueryHandler(_context, _mapper);

            //Act
            var result = await handler.Handle(
                new GetAllRecipeListQuery(),
                CancellationToken.None
            );

            //Assert
            result.ShouldBeOfType<RecipeListVm>();
            result.Recipes.Count.ShouldBe(4);
        }
    }
}