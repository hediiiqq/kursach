namespace kursach.Models;

public class GameModel
{
    public int Id { get; set; }
    public string? Title { get; set; } = string.Empty;
    public string? ImageURL { get; set; } = string.Empty;
    public string? ShortDescription { get; set; } = string.Empty;
    public string? ReleaseDate { get; set; } = string.Empty;
    public string? TimeOfPassage { get; set; } = string.Empty;
}