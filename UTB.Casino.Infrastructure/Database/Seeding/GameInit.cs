using UTB.Casino.Domain.Entities;
namespace UTB.Casino.Infrastructure.Database.Seeding;

internal class GameInit
{
    public IList<Domain.Entities.Game> GetGames2()
    {
        IList<Domain.Entities.Game> games = new List<Domain.Entities.Game>();
        
        games.Add(new Domain.Entities.Game
        {
            Id = 1,
            Name = "FreeSpin",
            Description =  "You can spin the cool wheel and save up for your Mortgage",
            Cost = 50,
            Picture = "/fotecka",
            AltPicture = "FreeSpinMashine"
        });
        games.Add(new Domain.Entities.Game
        {
            Id = 2,
            Name = "Roulette",
            Description =  "You can win",
            Cost = 100,
            Picture = "/fotecka",
            AltPicture = "Wheel"
        });
        
        return games;
    }
}