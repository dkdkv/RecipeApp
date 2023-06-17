namespace RecipeApp.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }

    public Category(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Name cannot be null or empty.", nameof(name));
        }
        Name = name;
    }
}
