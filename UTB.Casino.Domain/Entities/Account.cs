using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UTB.Casino.Domain.Entities.Interfaces;

namespace UTB.Casino.Domain.Entities;

[Table(nameof(Account))]
public class Account : Entity<int>
{
    [Required]
    public double Balance { get; set; }
    [Required] 
    public string Currency { get; set; }

    
    public ICollection<GameSession> GameSessions { get; set; } = new List<GameSession>();

    public ICollection<Transaction> Customers { get; set; } = new List<Transaction>();
}