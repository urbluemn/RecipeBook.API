﻿using MediatR;
using Recipes.Domain;
using Recipes.Application.Interfaces;

namespace Recipes.Application.Models.Commands.CreateModel
{
    /// <summary>
    /// Create Recipe
    /// </summary>
    public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, Guid>
    {
        private readonly IRecipeDbContext _dbContext;
        public CreateRecipeCommandHandler(IRecipeDbContext dbContext) => _dbContext = dbContext;
        public async Task<Guid> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipe = new Recipe
            {
                Username = request.Username,
                UserId = request.UserId,
                Name = request.Name,
                Description = request.Description,
                Details = request.Details,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                EditDate = null
            };

            await _dbContext.Recipes.AddAsync(recipe, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return recipe.Id;
        }
    }
}
