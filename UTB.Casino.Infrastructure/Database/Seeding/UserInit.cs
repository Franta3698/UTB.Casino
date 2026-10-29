using UTB.Casino.Infrastructure.Identity;

namespace UTB.Casino.Infrastructure.Database.Seeding;

internal class UserInit
{
    public User GetAdmin()
    {
        return new User
        {
            Id = 1,
            FirstName = "Admin",
            LastName = "Adminovy",
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            Email = "admin@casino.cz",
            NormalizedEmail = "ADMIN@CASINO.CZ",
            EmailConfirmed = true,
            AccountId = 1,

            PasswordHash = "...",

            SecurityStamp = "...",
            ConcurrencyStamp = "..."
        };
    }

    public User GetPlayer()
    {
        return new User
        {
            Id = 2,
            FirstName = "Jan",
            LastName = "Hracovy",
            UserName = "player",
            NormalizedUserName = "PLAYER",
            Email = "player@casino.cz",
            NormalizedEmail = "PLAYER@CASINO.CZ",
            EmailConfirmed = true,
            AccountId = 1,
            PasswordHash = "...",

            SecurityStamp = "...",
            ConcurrencyStamp = "..."
        };
    }
}