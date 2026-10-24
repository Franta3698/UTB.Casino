using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UTB.Eshop.Domain.Validations;

namespace UTB.Casino.Domain.Entities;
[Table(nameof(Game))]
public class Game : Entity <int>
{
    [Required]
    [FirstLetterUppercase]
    [StringLength(50)]
    public string Name { get; set; }
    public string Description { get; set; }
    public double Cost { get; set; }
    public string Picture { get; set; }
    
    public string AltPicture { get; set; }
}