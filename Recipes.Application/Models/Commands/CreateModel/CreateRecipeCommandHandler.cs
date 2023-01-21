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
        public async Task<Guid> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipe = new Recipe
            {
                UserId = request.UserID,
                Name = request.Name,
                Description = request.Decription,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                Details = request.Details
            };

            await _dbContext.Recipes.AddAsync(recipe, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return recipe.Id;
        }
    }
}
