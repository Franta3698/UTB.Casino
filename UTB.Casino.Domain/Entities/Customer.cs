using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTB.Casino.Domain.Entities;

[Table(nameof(Customer))]
public class Customer : Entity<int>
{
    [Required]
    public string UserName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    public string? PhoneNumber { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }


    [ForeignKey(nameof(Account))]
    public int AccountId { get; set; }
    public Account Account { get; set; }
}