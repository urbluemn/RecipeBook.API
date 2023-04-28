using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Recipes.Application.Common.Exceptions;
using Recipes.Application.Interfaces;
using Recipes.Domain;

namespace Recipes.Application.Models.Commands.SaveRecipe.DeleteSaved
{
    public class DeleteSavedRecipeCommandHandler : IRequestHandler<DeleteSavedRecipeCommand>
    {
        private readonly IRecipeDbContext _dbContext;

        public DeleteSavedRecipeCommandHandler(IRecipeDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteSavedRecipeCommand request, CancellationToken cancellationToken)
        {
             var entity = _dbContext.UserSavedRecipes
                .Where(recipe => recipe.RecipeId == request.RecipeId && recipe.UserId == request.UserId).FirstOrDefault();
            if (entity == null || entity.UserId != request.UserId || entity.RecipeId != request.RecipeId)
            {
                throw new NotFoundException(nameof(UserSavedRecipe), request.RecipeId);
            }

            _dbContext.UserSavedRecipes.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}