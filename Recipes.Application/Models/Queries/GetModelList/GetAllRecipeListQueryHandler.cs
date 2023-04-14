using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Recipes.Application.Interfaces;
using Recipes.Domain;

namespace Recipes.Application.Models.Queries.GetModelList
{
    /// <summary>
    /// Request handler to get all recipes
    /// </summary>
    public class GetAllRecipeListQueryHandler : IRequestHandler<GetAllRecipeListQuery, RecipeListVm>
    {
        private readonly IRecipeDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllRecipeListQueryHandler(IRecipeDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<RecipeListVm> Handle(GetAllRecipeListQuery request, CancellationToken cancellationToken)
        {
            var recipeQuery = await _dbContext.Recipes
                .Select(recipe => recipe)
                //.Skip(request.pageNumber * request.pageSize).Take(request.pageSize)
                .ProjectTo<RecipeLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new RecipeListVm { Recipes = recipeQuery };
        }
    }
}