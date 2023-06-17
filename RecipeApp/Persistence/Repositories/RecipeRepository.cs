using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Persistence.Repositories
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Recipe> _dbSet;

        public RecipeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Recipe>();
        }

        // Get recipes for a specific user
        public async Task<IEnumerable<Recipe>> GetRecipesByUserIdAsync(Guid userId)
        {
            return await _dbSet.Where(recipe => recipe.UserId == userId).ToListAsync();
        }

        // Add any other recipe specific methods here
    }
}