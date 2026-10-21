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
    [ForeignKey(nameof(Game))] 
    public int GameId { get; set; }
}