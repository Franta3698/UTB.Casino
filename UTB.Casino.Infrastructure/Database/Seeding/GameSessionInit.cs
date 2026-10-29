using UTB.Casino.Domain.Entities;

namespace UTB.Casino.Infrastructure.Database.Seeding;

internal class GameSessionInit
{
    public GameSession GetAdminSession()
    {
        return new GameSession
        {
            Id = 1,
            StartTime = new DateTime(2026, 10, 20, 14, 0, 0),
            EndTime = new DateTime(2026, 10, 20, 14, 30, 0),
            GameId = 1,
            AccountId = 1,
            Exchange = 100.0
        };
    }

    public GameSession GetPlayerSession()
    {
        return new GameSession
        {
            Id = 2,
            StartTime = new DateTime(2026, 10, 21, 16, 0, 0),
            EndTime = new DateTime(2026, 10, 21, 16, 45, 0),
            GameId = 2,
            AccountId = 2,
            Exchange = 50.0
        };
    }
}