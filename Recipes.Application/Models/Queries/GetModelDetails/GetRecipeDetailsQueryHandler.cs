using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Recipes.Application.Common.Exceptions;
using Recipes.Application.Interfaces;
using Recipes.Domain;

namespace Recipes.Application.Models.Queries.GetModelDetails
{
    public class GetRecipeDetailsQueryHandler : IRequestHandler<GetRecipeDetailsQuery, RecipeDetailsVm>
    {
        private readonly IRecipeDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetRecipeDetailsQueryHandler(IRecipeDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<RecipeDetailsVm> Handle(GetRecipeDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Recipes
                .FirstOrDefaultAsync(recipe => recipe.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Recipe), request.Id);
            }

            return _mapper.Map<RecipeDetailsVm>(entity);
        }
    }
}
