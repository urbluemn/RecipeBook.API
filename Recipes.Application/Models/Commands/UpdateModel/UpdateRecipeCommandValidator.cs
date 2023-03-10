using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Recipes.Application.Models.Commands.UpdateModel
{
    public class UpdateRecipeCommandValidator : AbstractValidator<UpdateRecipeCommand>
    {
        public UpdateRecipeCommandValidator()
        {
            RuleFor(updateRecipeCommand =>
                updateRecipeCommand.Name).NotEmpty().MaximumLength(100);
            RuleFor(updateRecipeCommand =>
                updateRecipeCommand.Description).NotEmpty().MaximumLength(250);
            RuleFor(updateRecipeCommand =>
                updateRecipeCommand.Details).NotEmpty().MaximumLength(1000);
            RuleFor(updateRecipeCommand =>
                updateRecipeCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateRecipeCommand =>
                updateRecipeCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
