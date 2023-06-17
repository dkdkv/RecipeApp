using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipeApp.API.Models.Update;
using RecipeApp.Application.Interfaces;
using RecipeApp.Application.ViewModel.IngredientViewModel;

namespace RecipeApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;
        private readonly IMapper _mapper;

        public IngredientController(IIngredientService ingredientService, IMapper mapper)
        {
            _ingredientService = ingredientService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<IngredientViewModel>> GetAll()
        {
            var ingredients = await _ingredientService.GetAllAsync();
            var ingredientsViewModel = ingredients.Select(_mapper.Map<IngredientViewModel>);
            return ingredientsViewModel;
        }

        [HttpGet("{id}", Name = "GetIngredientById")]
        public async Task<ActionResult<IngredientViewModel>> GetById(Guid id)
        {
            var ingredient = await _ingredientService.GetAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }

            var ingredientViewModel = _mapper.Map<IngredientViewModel>(ingredient);
            return Ok(ingredientViewModel);
        }

        [HttpPost]
        public async Task<ActionResult<IngredientViewModel>> Create(CreateIngredientViewModel createIngredientViewModel)
        {
            var createdViewModel = await _ingredientService.AddAsync(createIngredientViewModel);
            return CreatedAtAction(nameof(GetById), new { id = createdViewModel.Id }, createdViewModel);
        }

        [HttpPut("{id}", Name = "UpdateIngredient")]
        public async Task<ActionResult<IngredientViewModel>> Update(Guid id, UpdateIngredientModel updateIngredientViewModel)
        {
            var ingredient = await _ingredientService.GetAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            
            var mappedViewModel = _mapper.Map<UpdateIngredientViewModel>(updateIngredientViewModel);
            mappedViewModel.Id = id;
            
            var ingredientViewModel = await _ingredientService.UpdateAsync(mappedViewModel);
            return Ok(ingredientViewModel);
        }

        [HttpDelete("{id}", Name = "DeleteIngredient")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var ingredient = await _ingredientService.GetAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            
            var mappedViewModel = _mapper.Map<IngredientViewModel>(ingredient);
            await _ingredientService.DeleteAsync(mappedViewModel);
            return NoContent();
        }
    }
}
