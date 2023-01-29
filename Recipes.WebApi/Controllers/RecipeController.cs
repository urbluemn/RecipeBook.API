using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Recipes.Application.Models.Commands.CreateModel;
using Recipes.Application.Models.Commands.DeleteModel;
using Recipes.Application.Models.Commands.UpdateModel;
using Recipes.Application.Models.Queries.GetModelDetails;
using Recipes.Application.Models.Queries.GetModelList;
using Recipes.Domain;
using Recipes.WebApi.Models;

namespace Recipes.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class RecipeController : BaseController
    {
        private readonly IMapper _mapper;

        public RecipeController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<RecipeListVm>> GetAll()
        {
            var query = new GetRecipeListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeDetailsVm>> GetDetails(Guid id)
        {
            var query = new GetRecipeDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateRecipeDto createRecipeDto)
        {
            var command = _mapper.Map<CreateRecipeCommand>(createRecipeDto);
            command.UserID = UserId;
            var noteid = await Mediator.Send(command);
            return Ok(noteid);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateRecipeDto updateRecipeDto)
        {
            var command = _mapper.Map<UpdateRecipeCommand>(updateRecipeDto);
            command.UserID = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteRecipeCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}