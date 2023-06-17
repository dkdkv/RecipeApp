namespace RecipeApp.Application.ViewModel.RecipeViewModel;

public class UpdateRecipeViewModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    public int PrepTime { get; set; }
    public int CookTime { get; set; }
    public int Servings { get; set; }
    public string Difficulty { get; set; }
}