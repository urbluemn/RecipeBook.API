using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Recipes.Application.Interfaces;

namespace Recipes.Application.Models.Queries.GetModelList
{
    //TODO: Change to return every Recipe not concrete users Recipes
    /// <summary>
    /// Return List of Recipes
    /// </summary>
    public class GetRecipeListQueryHandler : IRequestHandler<GetRecipeListQuery, RecipeListVm>
    {
        private readonly IRecipeDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetRecipeListQueryHandler(IRecipeDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<RecipeListVm> Handle(GetRecipeListQuery request, CancellationToken cancellationToken)
        {
            var recipeQuery = await _dbContext.Recipes
                .Where(recipe => recipe.UserId == request.UserId)
                .ProjectTo<RecipeLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new RecipeListVm { Recipes = recipeQuery };
        }
    }
}
