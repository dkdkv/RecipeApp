namespace RecipeApp.Domain.Entities;

public class Recipe: BaseEntity
{
    public string Title { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    public int PrepTime { get; set; }
    public int CookTime { get; set; }
    public int Servings { get; set; }
    public string Difficulty { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    public ICollection<RecipeStep> RecipeSteps { get; set; }
    public ICollection<RecipeCategory> RecipeCategories { get; set; }
    
    public Recipe()
    {
        // Parameterless constructor
    }
}