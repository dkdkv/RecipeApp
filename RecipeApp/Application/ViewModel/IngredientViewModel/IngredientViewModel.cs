using RecipeApp.Application.Interfaces;

namespace RecipeApp.Application.ViewModel.IngredientViewModel
{
    public class IngredientViewModel : IViewModel
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
