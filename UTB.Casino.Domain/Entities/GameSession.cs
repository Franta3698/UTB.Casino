using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTB.Casino.Domain.Entities;

[Table(nameof(GameSession))]
public class GameSession : Entity<int>
{
    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }


    [ForeignKey(nameof(GameId))]
    public int GameId { get; set; }
    public Game Game { get; set; }


    [ForeignKey(nameof(AccountId))]
    public int AccountId { get; set; }
    public Account Account { get; set; }

    [Required]
    public double Exchange { get; set; }
}