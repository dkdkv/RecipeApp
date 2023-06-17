using RecipeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeApp.Domain.Interfaces
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        Task<IEnumerable<Recipe>> GetRecipesByUserIdAsync(Guid userId);
        // Add any other recipe specific methods here
    }
}