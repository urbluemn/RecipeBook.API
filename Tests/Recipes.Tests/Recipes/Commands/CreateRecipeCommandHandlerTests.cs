using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Recipes.Application.Models.Commands.CreateModel;
using Recipes.Persistence;
using Recipes.Tests.Common;

namespace Recipes.Tests.Recipes.Commands
{
    [Collection("CommandCollection")]
    public class CreateRecipeCommandHandlerTests /*: CommandTestBase*/
    {
        private readonly RecipeDbContext _context;

        public CreateRecipeCommandHandlerTests(CommandTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public async Task CreateRecipeCommandHandler_Success()
        {
            //Arrange
            var handler = new CreateRecipeCommandHandler(_context);
            var recipeName = "recipe name";
            var recipeDescription = "recipe description";
            var recipeDetails = "recipe details";

            //Act
            var recipeId = await handler.Handle(
                new CreateRecipeCommand
                {
                    Name = recipeName,
                    Details = recipeDetails,
                    Description = recipeDescription,
                    UserId = RecipesContextFactory.UserAId
                },
                CancellationToken.None
            );

            //Assert
            Assert.NotNull(
                await _context.Recipes.SingleOrDefaultAsync(recipe =>
                recipe.Id == recipeId
                && recipe.Name == recipeName
                && recipe.Details == recipeDetails
                && recipe.Description == recipeDescription)
            );
        }
    }
}