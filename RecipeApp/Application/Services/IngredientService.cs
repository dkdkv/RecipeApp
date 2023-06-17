// IngredientService.cs
using AutoMapper;
using RecipeApp.Application.Interfaces;
using RecipeApp.Application.ViewModel.IngredientViewModel;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Interfaces;

namespace RecipeApp.Application.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IRepository<Ingredient> _ingredientRepository;
        private readonly IMapper _mapper;

        public IngredientService(IRepository<Ingredient> ingredientRepository, IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }

        public async Task<IngredientViewModel?> GetAsync(Guid id)
        {
            var ingredient = await _ingredientRepository.GetAsync(id);
            return _mapper.Map<IngredientViewModel>(ingredient);
        }

        public async Task<IEnumerable<IngredientViewModel?>> GetAllAsync()
        {
            var ingredients = await _ingredientRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<IngredientViewModel>>(ingredients);
        }

        public async Task<IngredientViewModel> AddAsync(CreateIngredientViewModel ingredientViewModel)
        {
            var ingredient = _mapper.Map<Ingredient>(ingredientViewModel);
            await _ingredientRepository.AddAsync(ingredient);
            return _mapper.Map<IngredientViewModel>(ingredient);
        }

        public async Task<IngredientViewModel> UpdateAsync(UpdateIngredientViewModel ingredientViewModel)
        {
            var ingredient = await _ingredientRepository.GetAsync(ingredientViewModel.Id) ?? throw new InvalidOperationException("Cannot update non-existing ingredient.");
            _mapper.Map(ingredientViewModel, ingredient);
            await _ingredientRepository.UpdateAsync(ingredient);
            return _mapper.Map<IngredientViewModel>(ingredient);
        }

        public async Task DeleteAsync(IngredientViewModel ingredientViewModel)
        {
            var ingredient = await _ingredientRepository.GetAsync(ingredientViewModel.Id) ?? throw new InvalidOperationException("Cannot delete non-existing ingredient.");
            await _ingredientRepository.DeleteAsync(ingredient);
        }
    }
}
