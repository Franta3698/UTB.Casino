using System.ComponentModel.DataAnnotations;

namespace UTB.Casino.ViewModels;

public class BonusViewModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; }

    [Required]
    [Range(0.01, 100000, ErrorMessage = "Hodnota bonusu musí být kladná.")]
    public double Amount { get; set; }

    [Required]
    public DateTime ValidUntil { get; set; }

    [Required]
    public bool IsUsed { get; set; }

    [Required]
    public int AccountId { get; set; }
}