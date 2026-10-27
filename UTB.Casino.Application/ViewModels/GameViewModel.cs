namespace UTB.Casino.Application.ViewModels;

public class GameViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public double Cost { get; set; }
    public string? Picture { get; set; }
    public string? AltPicture { get; set; }
}