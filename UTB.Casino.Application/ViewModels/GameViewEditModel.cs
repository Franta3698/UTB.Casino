using System.ComponentModel.DataAnnotations;
namespace UTB.Casino.Application.ViewModels;

public class GameEditViewModel
{
    public int Id { get; set; }

    [Required]
    [Range(0, 100000)]
    public double Cost { get; set; }
    
}