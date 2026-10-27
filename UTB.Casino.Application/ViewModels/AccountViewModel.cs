using System.ComponentModel.DataAnnotations;

namespace UTB.Casino.ViewModels;

public class AccountViewModel
{
    public int Id { get; set; }

    [Required]
    [Range(0, 10000000, ErrorMessage = "Zůstatek nemůže být záporný.")]
    public double Balance { get; set; }

    [Required]
    [StringLength(10)]
    public string Currency { get; set; } = "CZK"; // Výchozí měna
}