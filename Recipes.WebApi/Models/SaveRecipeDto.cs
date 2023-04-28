using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Recipes.Application.Common.Mappings;
using Recipes.Application.Models.Commands.SaveRecipe.Save;

namespace Recipes.WebApi.Models
{
    public class SaveRecipeDto : IMapWith<SaveRecipeCommand>
    {
        public Guid RecipeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SaveRecipeDto, SaveRecipeCommand>()
                .ForMember(recipeCommand =>
                    recipeCommand.RecipeId, opt =>
                    opt.MapFrom(dto => dto.RecipeId));
        }
    }
}