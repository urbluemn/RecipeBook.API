using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Recipes.Application.Models.Commands.UpdateModel
{
    public class UpdateRecipeCommand : IRequest
    {
        public Guid UserID { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
    }
}
