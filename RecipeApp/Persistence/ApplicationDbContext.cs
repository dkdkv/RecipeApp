using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipeApp.Domain.Entities;

namespace RecipeApp.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<RecipeCategory> RecipeCategory { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredient { get; set; }
        public DbSet<RecipeStep> RecipeStep { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<RecipeIngredient>()
                .HasKey(ri => new { ri.RecipeId, ri.IngredientId });

            builder.Entity<RecipeCategory>()
                .HasKey(rc => new { rc.RecipeId, rc.CategoryId });

            base.OnModelCreating(builder);
        }
    }
}