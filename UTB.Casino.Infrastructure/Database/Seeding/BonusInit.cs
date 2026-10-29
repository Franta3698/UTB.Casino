using UTB.Casino.Domain.Entities;

namespace UTB.Casino.Infrastructure.Database.Seeding;

internal class BonusInit
{
    public Bonus GetWelcomeBonus()
    {
        return new Bonus
        {
            Id = 1,
            Title = "Uvítací bonus",
            Amount = 500.00,
            ValidUntil = new DateTime(2027, 12, 31),
            IsUsed = false,
            AccountId = 1
        };
    }

    public Bonus GetPlayerBonus()
    {
        return new Bonus
        {
            Id = 2,
            Title = "Bonus pro hráče",
            Amount = 200.00,
            ValidUntil = new DateTime(2027, 6, 30),
            IsUsed = false,
            AccountId = 2
        };
    }
}