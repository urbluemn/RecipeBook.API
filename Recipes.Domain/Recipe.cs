﻿using Microsoft.AspNetCore.Http;
namespace Recipes.Domain
{
    public class Recipe
    {
        public string Username { get; set; }
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        //public List<IFormFile>? RecipeImages { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
    }
}
