// IIngredientService.cs
using RecipeApp.Application.ViewModel.IngredientViewModel;

namespace RecipeApp.Application.Interfaces
{
    public interface IIngredientService : IViewModelService<IngredientViewModel>
    {
        Task<IngredientViewModel> AddAsync(CreateIngredientViewModel entity);
        Task<IngredientViewModel> UpdateAsync(UpdateIngredientViewModel entity);
    }
}