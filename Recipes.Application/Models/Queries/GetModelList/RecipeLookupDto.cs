﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Recipes.Application.Common.Mappings;
using Recipes.Domain;

namespace Recipes.Application.Models.Queries.GetModelList
{
    /// <summary>
    /// Viewmodel for recipe
    /// </summary>
    public class RecipeLookupDto : IMapWith<Recipe>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Recipe, RecipeLookupDto>()
                .ForMember(recipeDto => recipeDto.Id,
                    opts => opts.MapFrom(recipe => recipe.Id))
                .ForMember(recipeDto => recipeDto.Name,
                    opts =>
                    opts.MapFrom(recipe => recipe.Name))
                .ForMember(recipeDto => recipeDto.Description,
                    opts =>
                        opts.MapFrom(recipe => recipe.Description));
        }
    }
}
