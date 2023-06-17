namespace RecipeApp.Domain.Entities;

public class RecipeIngredient
{
    public Guid Id { get; set; }
    public Guid RecipeId { get; set; }
    public Recipe Recipe { get; set; }
    public Guid IngredientId { get; set; }
    public Ingredient Ingredient { get; set; }
    public decimal Quantity { get; set; }
    public string Unit { get; set; }
    
    public RecipeIngredient(Guid recipeId, Guid ingredientId, decimal quantity, string unit)
    {
        RecipeId = recipeId;
        IngredientId = ingredientId;
        Quantity = quantity;
        Unit = unit;
    }
}