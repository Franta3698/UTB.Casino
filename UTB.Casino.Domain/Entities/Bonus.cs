using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTB.Casino.Domain.Entities;

[Table(nameof(Bonus))]
public class Bonus : Entity<int>
{
    [Required]
    [StringLength(100)]
    public string Title { get; set; } 

    [Required]
    public double Amount { get; set; } 

    [Required]
    public DateTime ValidUntil { get; set; } 

    [Required]
    public bool IsUsed { get; set; } 

    
    [ForeignKey(nameof(Account))]
    public int AccountId { get; set; }
    public Account Account { get; set; }
}