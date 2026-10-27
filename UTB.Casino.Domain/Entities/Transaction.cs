using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace UTB.Casino.Domain.Entities;

public class Transaction : Entity<int>
{
    [Required]
    public double Amount { get; set; } // Částka transakce

    [Required]
    public DateTime Date { get; set; } // Datum a čas transakce

    [Required]
    [StringLength(50)]
    public string Type { get; set; } // Např. "Deposit" (Vklad), "Withdrawal" (Výběr)

    // --- Vztah k účtu ---
    [ForeignKey(nameof(Account))]
    public int AccountId { get; set; }
    public Account Account { get; set; }
    
    [ForeignKey(nameof(Customer))]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}