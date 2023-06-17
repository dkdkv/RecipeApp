namespace RecipeApp.Domain.Entities;

public class RecipeCategory
{
    public Guid Id { get; set; }
    public Guid RecipeId { get; set; }
    public Recipe Recipe { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }

    public RecipeCategory(Guid recipeId, Guid categoryId)
    {
        RecipeId = recipeId;
        CategoryId = categoryId;
    }
}