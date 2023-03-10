using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Recipes.Application.Common.Exceptions;
using Recipes.Application.Models.Commands.UpdateModel;
using Recipes.Persistence;
using Recipes.Tests.Common;

namespace Recipes.Tests.Recipes.Commands
{
    [Collection("CommandCollection")]
    public class UpdateRecipeCommandHandlerTests /*: CommandTestBase*/
    {
        private readonly RecipeDbContext _context;

        public UpdateRecipeCommandHandlerTests(CommandTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public async Task UpdateRecipeCommandHandler_Success()
        {
            //Arrange
            var handler = new UpdateRecipeCommandHandler(_context);
            var updatedName = "UpdatedRecipeName";

            //Act
            var recipeId = await handler.Handle(
                new UpdateRecipeCommand
                {
                    Id = RecipesContextFactory.RecipeIdForUpdate,
                    UserId = RecipesContextFactory.UserBId,
                    Name = updatedName
                },
                CancellationToken.None
            );

            //Assert
            Assert.NotNull(
                await _context.Recipes.SingleOrDefaultAsync(recipe =>
                recipe.Id == RecipesContextFactory.RecipeIdForUpdate
                && recipe.Name == updatedName)
            );
        }

        [Fact]
        public async Task UpdateRecipeCommandHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new UpdateRecipeCommandHandler(_context);
            var updatedName = "Updated Name";

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateRecipeCommand
                {
                    Id = Guid.NewGuid(),
                    UserId = RecipesContextFactory.UserBId,
                    Name = updatedName
                },
                CancellationToken.None
            ));
        }

        [Fact]
        public async Task UpdateRecipeCommandHandler_FailOnWrongUserId()
        {
            //Arrange
            var handler = new UpdateRecipeCommandHandler(_context);
            var updatedName = "updated name";

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateRecipeCommand
                {
                    Id = RecipesContextFactory.RecipeIdForUpdate,
                    UserId = RecipesContextFactory.UserAId,
                    Name = updatedName
                },
                CancellationToken.None
            ));
        }
    }
}