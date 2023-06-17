using RecipeApp.Application.ViewModel.RecipeViewModel;

namespace RecipeApp.Application.Interfaces
{
    public interface IRecipeService : IViewModelService<RecipeViewModel>
    {
        Task<RecipeViewModel> AddAsync(CreateRecipeViewModel entity);
        Task<RecipeViewModel> UpdateAsync(UpdateRecipeViewModel entity);
        Task<IEnumerable<RecipeViewModel>> GetRecipesByUserIdAsync(Guid userId);
    }
}