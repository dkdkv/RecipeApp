using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipeApp.API.Models.Update;
using RecipeApp.Application.Interfaces;
using RecipeApp.Application.ViewModel.RecipeViewModel;

namespace RecipeApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly IMapper _mapper;

        public RecipeController(IRecipeService recipeService, IMapper mapper)
        {
            _recipeService = recipeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<RecipeViewModel?>> GetAll()
        {
            return await _recipeService.GetAllAsync();
        }

        [HttpGet("{id}", Name = "GetRecipeById")]
        public async Task<ActionResult<RecipeViewModel?>> GetById(Guid id)
        {
            var recipe = await _recipeService.GetAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(recipe);
        }

        [HttpPost]
        public async Task<ActionResult<RecipeViewModel>> Create(CreateRecipeViewModel createViewModel)
        {
            var recipe = await _recipeService.AddAsync(createViewModel);
            return CreatedAtAction(nameof(GetById), new { id = recipe.Id }, recipe);
        }

        [HttpPut("{id}", Name = "UpdateRecipe")]
        public async Task<ActionResult<RecipeViewModel>> Update(Guid id, UpdateRecipeModel updateViewModel)
        {
            var mappedModel = _mapper.Map<UpdateRecipeViewModel>(updateViewModel);
            var recipe = await _recipeService.UpdateAsync(mappedModel);
            return recipe;
        }

        [HttpDelete("{id}", Name = "DeleteRecipe")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var recipe = await _recipeService.GetAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            var mappedModel = _mapper.Map<RecipeViewModel>(recipe);
            await _recipeService.DeleteAsync(mappedModel);
            return NoContent();
        }
    }
}
