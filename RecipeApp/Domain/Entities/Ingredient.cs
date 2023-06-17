namespace RecipeApp.Domain.Entities;

public class Ingredient: BaseEntity
{
    public string Name { get; set; }
    
    public Ingredient(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Name cannot be null or empty.", nameof(name));
        }
        Name = name;
    }
}