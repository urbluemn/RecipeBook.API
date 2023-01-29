using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Recipes.Application.Models.Commands.DeleteModel
{
    public class DeleteRecipeCommandValidator : AbstractValidator<DeleteRecipeCommand>
    {
        public DeleteRecipeCommandValidator()
        {
            RuleFor(deleteRecipeCommand =>
                deleteRecipeCommand.Id).NotEqual(Guid.Empty);
            RuleFor(deleteRecipeCommand =>
                deleteRecipeCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
