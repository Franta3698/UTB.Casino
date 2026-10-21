using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UTB.Casino.Domain.Entities.Interfaces;
namespace UTB.Casino.Domain.Entities;

[Table(nameof(Account))]
public class Account : Entity<int>
{
    [Required]
    public double balance { get; set; }

    [Required] 
    public string currency { get; set; }
}