using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Recipes.Application.Common.Exceptions;
using Recipes.Application.Interfaces;
using Recipes.Domain;

namespace Recipes.Application.Models.Commands.SaveRecipe.Save
{
    public class SaveRecipeCommandHandler : IRequestHandler<SaveRecipeCommand, Unit>
    {
        private readonly IRecipeDbContext _dbContext;
        public SaveRecipeCommandHandler(IRecipeDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(SaveRecipeCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbContext.UserSavedRecipes
                .Where(recipe => recipe.RecipeId == request.RecipeId && recipe.UserId == request.UserId).FirstOrDefault();
            if (entity != null)
            {
                throw new NotFoundException(nameof(UserSavedRecipe), request.RecipeId);
            }
            var savedRecipe = new UserSavedRecipe
            {
                OperationId = Guid.NewGuid(),
                UserId = request.UserId,
                RecipeId = request.RecipeId
            };

            await _dbContext.UserSavedRecipes.AddAsync(savedRecipe, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}