namespace kursach.Models;

public class BaseModel
{
    public int Id { get; set; }
    public string? Title { get; set; } =  string.Empty;
    public string? ImageURL { get; set; } = string.Empty;
    public string? ShortDescription { get; set; } = string.Empty;
    public int TimeToCookInMinutes { get; set; }
    public string? Ingridients { get; set; } = string.Empty;
    public string? FullDescription { get; set; } = string.Empty;
}