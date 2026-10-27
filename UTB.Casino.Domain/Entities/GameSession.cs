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

    // --- Vztah ke hře (Game) ---
    [ForeignKey(nameof(GameId))] // Doporučeno odkazovat přímo na ID, nebo stačí uvést navigační vlastnost níže
    public int GameId { get; set; }
    public Game Game { get; set; } // <--- Přidáno: Navigační vlastnost

    // --- Vztah k uživateli/účtu (Account) ---
    [ForeignKey(nameof(AccountId))]
    public int AccountId { get; set; }
    public Account Account { get; set; } // <--- Přidáno: Navigační vlastnost

    [Required]
    public double Exchange { get; set; }
}