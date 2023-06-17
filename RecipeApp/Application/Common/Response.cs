namespace RecipeApp.Application.Common;

public class Response
{
    public string? Status { get; set; }
    public string? Message { get; set; }
    public object? Data { get; set; }
    
    public Response(string? status, string? message, object? data = null)
    {
        Status = status;
        Message = message;
        Data = data;
    }
}