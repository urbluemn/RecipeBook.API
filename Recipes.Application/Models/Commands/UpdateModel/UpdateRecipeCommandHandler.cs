using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Recipes.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Recipes.Application.Models.Commands.UpdateModel
{
    public class UpdateRecipeCommandHandler : IRequestHandler<UpdateRecipeCommand, Unit>
    {
        private readonly IRecipeDbContext _dbContext;

        public UpdateRecipeCommandHandler(IRecipeDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateRecipeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Recipes.FirstOrDefaultAsync(recipe => recipe.Id == command.Id, cancellationToken);

            if (entity == null || entity.UserId != command.UserID) 
            {

            }
            return Unit.Value;
        }
    }
}
