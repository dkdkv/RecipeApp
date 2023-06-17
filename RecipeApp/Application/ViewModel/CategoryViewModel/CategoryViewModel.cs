using System.Text.Json.Serialization;
using RecipeApp.Application.Interfaces;

namespace RecipeApp.Application.ViewModel.CategoryViewModel
{
    public class CategoryViewModel : IViewModel
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}