using AutoMapper;
using Recipes.Application.Common.Mappings;
using Recipes.Application.Models.Commands.UpdateModel;

namespace Recipes.WebApi.Models
{
    public class UpdateRecipeDto : IMapWith<UpdateRecipeCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateRecipeDto, UpdateRecipeCommand>()
                .ForMember(recipeCommand =>
                    recipeCommand.Id, opt =>
                    opt.MapFrom(dto => dto.Id))
                .ForMember(recipeCommand =>
                    recipeCommand.Name, opt =>
                    opt.MapFrom(dto => dto.Name))
                .ForMember(recipeCommand =>
                    recipeCommand.Description, opt =>
                    opt.MapFrom(dto => dto.Description))
                .ForMember(recipeCommand =>
                    recipeCommand.Details, opt =>
                    opt.MapFrom(dto => dto.Details));
        }
    }
}
