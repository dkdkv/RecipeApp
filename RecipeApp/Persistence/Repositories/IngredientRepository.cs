using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Interfaces;

namespace RecipeApp.Persistence.Repositories
{
    public class IngredientRepository : Repository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
