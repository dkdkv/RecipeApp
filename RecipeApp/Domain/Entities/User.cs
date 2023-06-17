using Microsoft.AspNetCore.Identity;

namespace RecipeApp.Domain.Entities;

public class User : IdentityUser
{
    public ICollection<Recipe> Recipes { get; set; }
}
