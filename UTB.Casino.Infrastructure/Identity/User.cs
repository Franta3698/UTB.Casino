using Microsoft.AspNetCore.Identity;
using UTB.Casino.Domain.Entities;
using UTB.Casino.Domain.Entities.Interfaces;

namespace UTB.Casino.Infrastructure.Identity;

public class User : IdentityUser<int>, IUser<int>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public int AccountId { get; set; }
    public Account Account { get; set; } = null!;
}