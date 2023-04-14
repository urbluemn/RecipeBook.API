using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MediatR;
using Recipes.Domain;
using Microsoft.AspNetCore.Http;

namespace Recipes.Application.Models.Commands.CreateModel
{
    public class CreateRecipeCommand : IRequest<Guid>
    {
        public string Username { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Details { get; set; }
    }
}
