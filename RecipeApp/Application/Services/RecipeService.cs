using AutoMapper;
using RecipeApp.Application.Interfaces;
using RecipeApp.Application.ViewModel.RecipeViewModel;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Interfaces;

namespace RecipeApp.Application.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _repository;
        private readonly IMapper _mapper;

        public RecipeService(IRecipeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RecipeViewModel?> GetAsync(Guid id)
        {
            var recipe = await _repository.GetAsync(id);
            return _mapper.Map<RecipeViewModel>(recipe);
        }

        public async Task<IEnumerable<RecipeViewModel?>> GetAllAsync()
        {
            var recipes = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<RecipeViewModel>>(recipes);
        }

        public async Task<RecipeViewModel> AddAsync(CreateRecipeViewModel recipeViewModel)
        {
            var recipe = _mapper.Map<Recipe>(recipeViewModel);
            await _repository.AddAsync(recipe);
            return _mapper.Map<RecipeViewModel>(recipe);
        }

        public async Task<RecipeViewModel> UpdateAsync(UpdateRecipeViewModel recipeViewModel)
        {
            var recipe = _mapper.Map<Recipe>(recipeViewModel);
            await _repository.UpdateAsync(recipe);
            return _mapper.Map<RecipeViewModel>(recipe);
        }

        public async Task DeleteAsync(RecipeViewModel recipeViewModel)
        {
            var recipe = await _repository.GetAsync(recipeViewModel.Id) ?? throw new InvalidOperationException("Cannot delete non-existing recipe.");
            await _repository.DeleteAsync(recipe);
        }

        public async Task<IEnumerable<RecipeViewModel>> GetRecipesByUserIdAsync(Guid userId)
        {
            var recipes = await _repository.GetRecipesByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<RecipeViewModel>>(recipes);
        }
    }
}