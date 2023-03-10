using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recipes.Application.Common.Exceptions;
using Recipes.Application.Models.Commands.CreateModel;
using Recipes.Application.Models.Commands.DeleteModel;
using Recipes.Persistence;
using Recipes.Tests.Common;

namespace Recipes.Tests.Recipes.Commands
{
    [Collection("CommandCollection")]
    public class DeleteRecipeCommandHandlerTests /*: CommandTestBase*/
    {
        private readonly RecipeDbContext _context;

        public DeleteRecipeCommandHandlerTests(CommandTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public async Task DeleteRecipeCommandHandler_Success()
        {
            //Arrange
            var handler = new DeleteRecipeCommandHandler(_context);

            //Act
            await handler.Handle(new DeleteRecipeCommand
            {
                Id = RecipesContextFactory.RecipeIdForDelete,
                UserId = RecipesContextFactory.UserAId
            },
            CancellationToken.None);

            //Assert
            Assert.Null(_context.Recipes.SingleOrDefault(recipe =>
            recipe.Id == RecipesContextFactory.RecipeIdForDelete));
        }

        [Fact]
        public async Task DeleteRecipeCommandHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new DeleteRecipeCommandHandler(_context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteRecipeCommand
                {
                    Id = Guid.NewGuid(),
                    UserId = RecipesContextFactory.UserAId
                },
                CancellationToken.None
            ));
        }

        [Fact]
        public async Task DeleteRecipeCommandHandler_FailOnWrongUserId()
        {
            //Arrange
            var deleteHandler = new DeleteRecipeCommandHandler(_context);
            var createHandler = new CreateRecipeCommandHandler(_context);
            var recipeId = await createHandler.Handle(
                new CreateRecipeCommand
                {
                    Name = "RecipeName",
                    Description = "RecipeDescription",
                    Details = "RecipeDetails",
                    UserId = RecipesContextFactory.UserAId
                },
                CancellationToken.None
            );

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await deleteHandler.Handle(
                new DeleteRecipeCommand
                {
                    Id = recipeId,
                    UserId = RecipesContextFactory.UserBId
                },
                CancellationToken.None
            )
            );
        }
    }
}