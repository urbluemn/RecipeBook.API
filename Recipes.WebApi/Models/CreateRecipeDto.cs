using AutoMapper;
using Recipes.Application.Common.Mappings;
using Recipes.Application.Models.Commands.CreateModel;

namespace Recipes.WebApi.Models
{
    public class CreateRecipeDto : IMapWith<CreateRecipeCommand>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        //public DateTime CreationDate { get; set; }
        //public DateTime EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateRecipeDto, CreateRecipeCommand>()
                .ForMember(noteCommand => noteCommand.Name,
                    opt =>
                        opt.MapFrom(dto => dto.Name))
                .ForMember(noteCommand => noteCommand.Description,
                    opt =>
                        opt.MapFrom(dto => dto.Description))
                .ForMember(noteCommand => noteCommand.Details,
                    opt =>
                        opt.MapFrom(dto => dto.Details));
        }
    }
}
