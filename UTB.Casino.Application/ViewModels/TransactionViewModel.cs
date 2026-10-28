using System.ComponentModel.DataAnnotations;

namespace UTB.Casino.ViewModels;

public class TransactionViewModel
{
    public int Id { get; set; }

    [Required]
    [Range(0.01, 1000000, ErrorMessage = "Částka musí být větší než 0.")]
    public double Amount { get; set; }

    [Required]
    public DateTime Date { get; set; } = DateTime.Now;

    [Required]
    [StringLength(50)]
    public string Type { get; set; }

    [Required]
    public int AccountId { get; set; }
}