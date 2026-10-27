using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UTB.Casino.Domain.Entities.Interfaces;

namespace UTB.Casino.Domain.Entities;

[Table(nameof(Account))]
public class Account : Entity<int>
{
    [Required]
    public double Balance { get; set; } // Změněno na velké B

    [Required] 
    public string Currency { get; set; } // Změněno na velké C

    // --- Zpětné navigační vlastnosti (Volitelně, ale velmi užitečné) ---
    
    // Pokud má jeden účet více herních sezení:
    public ICollection<GameSession> GameSessions { get; set; } = new List<GameSession>();

    // Pokud má účet zákazníky (záleží na vašem datovém modelu, zda je to 1:1 nebo 1:N):
    public ICollection<Customer> Customers { get; set; } = new List<Customer>();
}