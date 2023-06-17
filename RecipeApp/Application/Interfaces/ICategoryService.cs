using RecipeApp.Application.ViewModel.CategoryViewModel;

namespace RecipeApp.Application.Interfaces
{
    public interface ICategoryService : IViewModelService<CategoryViewModel>
    {
        Task<CategoryViewModel> AddAsync(CreateCategoryViewModel entity);
        Task<CategoryViewModel> UpdateAsync(UpdateCategoryViewModel entity);
    }
}