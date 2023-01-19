using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MediatR;

namespace Recipes.Application.Models.Commands.CreateModel
{
    public class CreateRecipeCommand : IRequest<Guid>
    {
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public string Decription { get; set; }
        public string? Details { get; set; }
    }
}
