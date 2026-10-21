using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTB.Casino.Domain.Entities;
[Table(nameof(Game))]
public class Game : Entity <int>
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public double Cost { get; set; }
    [Required]
    public string Picture { get; set; }
    
    [Required]
    public string AltPicture { get; set; }
}