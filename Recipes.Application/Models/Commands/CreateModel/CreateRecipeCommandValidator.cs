using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Recipes.Application.Models.Commands.CreateModel
{
    public class CreateRecipeCommandValidator : AbstractValidator<CreateRecipeCommand>
    {
        public CreateRecipeCommandValidator()
        {
            RuleFor(createRecipeCommand =>
                createRecipeCommand.Name).NotEmpty().MaximumLength(100);
            RuleFor(createRecipeCommand =>
                createRecipeCommand.Description).NotEmpty().MaximumLength(250);
            RuleFor(createRecipeCommand =>
                createRecipeCommand.Details).NotEmpty().MaximumLength(1000);
            RuleFor(createRecipeCommand =>
                createRecipeCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
