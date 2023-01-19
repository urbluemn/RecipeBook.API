using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recipes.Domain;
using Recipes.Application.Interfaces;

namespace Recipes.Application.Models.Commands.CreateModel
{
    public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, Guid>
    {
        private readonly IRecipeDbContext _dbContext;
        public CreateRecipeCommandHandler(IRecipeDbContext dbContext) => _dbContext = dbContext;
        public async Task<Guid> Handle(CreateRecipeCommand command, CancellationToken cancellationToken)
        {
            var recipe = new Recipe
            {
                UserId = command.UserID,
                Name = command.Name,
                Description = command.Decription,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                Details = command.Details
            };

            await _dbContext.Recipes.AddAsync(recipe, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return recipe.Id;
        }
    }
}
