using UTB.Casino.Domain.Entities;

namespace UTB.Casino.Infrastructure.Database.Seeding;

internal class AccountInit
{
    public Account GetAdminAccount()
    {
        return new Account
        {
            Id = 1,
            Balance = 10000.00,
            Currency = "CZK"
        };
    }

    public Account GetPlayerAccount()
    {
        return new Account
        {
            Id = 2,
            Balance = 1000.00,
            Currency = "CZK"
        };
    }
}