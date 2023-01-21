using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Recipes.Application.Common.Exceptions;
using Recipes.Application.Interfaces;
using Recipes.Domain;

namespace Recipes.Application.Models.Commands.DeleteModel
{
    public class DeleteRecipeCommandHandler : IRequestHandler<DeleteRecipeCommand>
    {
        private readonly IRecipeDbContext _dbContext;

        public DeleteRecipeCommandHandler(IRecipeDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Recipes
                .FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Recipe), request.Id);
            }

            _dbContext.Recipes.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
            
        }
    }
}
