using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace UTB.Casino.Domain.Entities;

[Table(nameof(Customer))]
public class Customer : Entity <int>
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [ForeignKey("Account")]
    public int? BankAccountId { get; set; }
}