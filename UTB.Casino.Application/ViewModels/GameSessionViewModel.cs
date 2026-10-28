using System.ComponentModel.DataAnnotations;

namespace UTB.Casino.ViewModels;

public class GameSessionViewModel
{
    public int Id { get; set; }

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }

    [Required]
    public int GameId { get; set; }

    [Required]
    public int AccountId { get; set; }

    [Required]
    public double Exchange { get; set; }
}