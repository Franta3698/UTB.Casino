using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UTB.Casino.Domain;

namespace UTB.Casino.Domain.Entities;
[Table(nameof(Game))]
public class Game : Entity <int>
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    public string Description { get; set; }
    [Required]
    [Range(0.01, 100000,  ErrorMessage = "Price must be between 0.01 and 100000.")]
    public double Cost { get; set; }
    public string Picture { get; set; }
    
    public string AltPicture { get; set; }
}