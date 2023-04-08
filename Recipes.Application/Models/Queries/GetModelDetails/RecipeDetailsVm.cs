using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Recipes.Application.Common.Mappings;
using Recipes.Domain;

namespace Recipes.Application.Models.Queries.GetModelDetails
{
    /// <summary>
    /// Mapped Recipe Model
    /// </summary>
    public class RecipeDetailsVm : IMapWith<Recipe>
    {
        public string Username { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Recipe, RecipeDetailsVm>()
                .ForMember(recipeVm => recipeVm.Username, opts =>
                    opts.MapFrom(recipe => recipe.Username))
                .ForMember(recipeVm => recipeVm.Id, opts =>
                    opts.MapFrom(recipe => recipe.Id))
                .ForMember(recipeVm => recipeVm.Name, opts =>
                    opts.MapFrom(recipe => recipe.Name))
                .ForMember(recipeVm => recipeVm.Description, opts =>
                    opts.MapFrom(recipe => recipe.Description))
                .ForMember(recipeVm => recipeVm.Details, opts =>
                    opts.MapFrom(recipe => recipe.Details))
                .ForMember(recipeVm => recipeVm.CreationDate, opts =>
                    opts.MapFrom(recipe => recipe.CreationDate))
                .ForMember(recipeVm => recipeVm.EditDate, opts =>
                    opts.MapFrom(recipe => recipe.EditDate));
        }
    }
}
