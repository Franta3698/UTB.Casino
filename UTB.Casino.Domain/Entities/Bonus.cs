using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTB.Casino.Domain.Entities;

[Table(nameof(Bonus))]
public class Bonus : Entity<int>
{
    [Required]
    [StringLength(100)]
    public string Title { get; set; } // Název bonusu (např. "Uvítací bonus 100%")

    [Required]
    public double Amount { get; set; } // Finanční hodnota bonusu

    [Required]
    public DateTime ValidUntil { get; set; } // Do kdy platí

    [Required]
    public bool IsUsed { get; set; } // Zda už byl bonus uplatněn (true/false)

    // --- Vztah k účtu ---
    [ForeignKey(nameof(Account))]
    public int AccountId { get; set; }
    public Account Account { get; set; }
}