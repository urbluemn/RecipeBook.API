using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Recipes.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Recipes.Application.Common.Exceptions;
using Recipes.Domain;

namespace Recipes.Application.Models.Commands.UpdateModel
{
    public class UpdateRecipeCommandHandler : IRequestHandler<UpdateRecipeCommand, Unit>
    {
        private readonly IRecipeDbContext _dbContext;

        public UpdateRecipeCommandHandler(IRecipeDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Recipes.FirstOrDefaultAsync(recipe => recipe.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Recipe), request.Id);
            }
            entity.Description = request.Description;
            entity.Name = request.Name;
            entity.Details = request.Details;
            entity.EditDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
