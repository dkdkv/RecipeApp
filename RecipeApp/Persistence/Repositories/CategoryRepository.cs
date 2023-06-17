using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Interfaces;

namespace RecipeApp.Persistence.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}