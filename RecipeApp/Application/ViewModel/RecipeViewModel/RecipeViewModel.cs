using RecipeApp.Application.Interfaces;

namespace RecipeApp.Application.ViewModel.RecipeViewModel;

public class RecipeViewModel : IViewModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    public int PrepTime { get; set; }
    public int CookTime { get; set; }
    public int Servings { get; set; }
    public string Difficulty { get; set; }
    public string UserName { get; set; } // Here we're just exposing user's name, not the whole User entity

    // You can choose to include or exclude related entities (like RecipeIngredients) depending on your needs
    // public ICollection<RecipeIngredientViewModel> RecipeIngredients { get; set; }
    // public ICollection<RecipeStepViewModel> RecipeSteps { get; set; }
    // public ICollection<RecipeCategoryViewModel> RecipeCategories { get; set; }
}