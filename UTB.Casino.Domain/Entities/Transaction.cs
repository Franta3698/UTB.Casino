using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTB.Casino.Domain.Entities;

public class Transaction : Entity<int>
{
    [Required]
    public double Amount { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    [StringLength(50)]
    public string Type { get; set; } = null!;

    public int AccountId { get; set; }

    [ForeignKey(nameof(AccountId))]
    public Account Account { get; set; } = null!;
}