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
    public class GetModelDetailsQueryHandler : IRequestHandler<GetModelDetailsQuery, ModelDetailsVm>
    {
        private readonly IRecipeDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetModelDetailsQueryHandler(IRecipeDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);
        
        public async Task<ModelDetailsVm> Handle(GetModelDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Recipes
                .FirstOrDefaultAsync(recipe => recipe.Id == request.Id, cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Recipe), request.Id);
            }

            return _mapper.Map<ModelDetailsVm>(entity);
        }
    }
}
