namespace RecipeApp.Domain.Entities;

public class RecipeStep: BaseEntity
{
    public Guid RecipeId { get; set; }
    public int StepNumber { get; set; }
    public string Description { get; set; }
    
    public RecipeStep(Guid recipeId, int stepNumber, string description)
    {
        if (stepNumber <= 0)
        {
            throw new ArgumentException("StepNumber cannot be less than or equal to zero.", nameof(stepNumber));
        }
        if (string.IsNullOrEmpty(description))
        {
            throw new ArgumentException("Description cannot be null or empty.", nameof(description));
        }
        RecipeId = recipeId;
        StepNumber = stepNumber;
        Description = description;
    }
}