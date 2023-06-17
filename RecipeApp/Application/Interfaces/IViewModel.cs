using System.Text.Json.Serialization;

namespace RecipeApp.Application.Interfaces;

public interface IViewModel
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Guid Id { get; set; }
}