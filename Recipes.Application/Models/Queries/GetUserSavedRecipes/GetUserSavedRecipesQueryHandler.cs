using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Recipes.Application.Interfaces;
using Recipes.Application.Models.Queries.GetModelList;

namespace Recipes.Application.Models.Queries.GetUserSavedRecipes
{
    public class GetUserSavedRecipesQueryHandler : IRequestHandler<GetUserSavedRecipesQuery, RecipeListVm>
    {
        private readonly IRecipeDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserSavedRecipesQueryHandler(IRecipeDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<RecipeListVm> Handle(GetUserSavedRecipesQuery request, CancellationToken cancellationToken)
        {
            var savedRecipeQuery = await _dbContext.UserSavedRecipes
                .Where(savedRecipe => savedRecipe.UserId == request.UserId)
                .Select(savedRecipe => savedRecipe.RecipeId).ToListAsync(cancellationToken);

            var recipesQuery = await _dbContext.Recipes.Where(recipe => savedRecipeQuery.Contains(recipe.Id))
                .ProjectTo<RecipeLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new RecipeListVm { Recipes = recipesQuery };
        }
    }
}