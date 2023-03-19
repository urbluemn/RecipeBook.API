using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipes.Application.Models.Commands.CreateModel;
using Recipes.Application.Models.Commands.DeleteModel;
using Recipes.Application.Models.Commands.UpdateModel;
using Recipes.Application.Models.Queries.GetModelDetails;
using Recipes.Application.Models.Queries.GetModelList;
using Recipes.WebApi.Models;

namespace Recipes.WebApi.Controllers
{
    [ApiVersionNeutral]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class RecipeController : BaseController
    {
        private readonly IMapper _mapper;

        public RecipeController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of recipes
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /recipe
        /// </remarks>
        /// <returns>Returns RecipeListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If user is unauthorized</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<RecipeListVm>> GetAll()
        {
            var query = new GetRecipeListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the concrete recipe details
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /recipe/{id}
        /// </remarks>
        /// <param name="id">Recipe id (guid)</param>
        /// <returns>Returns RecipeDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If user is unauthorized</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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

        /// <summary>
        /// Creates the recipe
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /recipe
        /// {
        ///     name: "recipe name",
        ///     description: "recipe description",
        ///     details: "recipe details"
        /// }
        /// </remarks>
        /// <param name="createRecipeDto">CreateRecipeDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If user is unauthorized</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateRecipeDto createRecipeDto)
        {
            var command = _mapper.Map<CreateRecipeCommand>(createRecipeDto);
            command.UserId = UserId;
            var recipeId = await Mediator.Send(command);
            return Ok(recipeId);
        }

        /// <summary>
        /// Updates the recipe by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /recipe/{id}
        /// {
        ///     name: "updated recipe name"
        /// }
        /// </remarks>
        /// <param name="updateRecipeDto">UpdateRecipeDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If user is unauthorized</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateRecipeDto updateRecipeDto)
        {
            var command = _mapper.Map<UpdateRecipeCommand>(updateRecipeDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the recipe by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /recipe/{id}
        /// </remarks>
        /// <param name="id">Id of the recipe (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If user is unauthorized</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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