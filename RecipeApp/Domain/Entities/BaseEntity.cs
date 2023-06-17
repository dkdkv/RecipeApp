namespace RecipeApp.Domain.Entities;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    
    public BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
    }
    
    public void Update()
    {
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void Delete()
    {
        DeletedAt = DateTime.UtcNow;
    }
    
    public void Restore()
    {
        DeletedAt = null;
    }
    
    public bool IsDeleted()
    {
        return DeletedAt != null;
    }
}