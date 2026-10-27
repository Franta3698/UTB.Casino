using UTB.Casino.Application.Abstraction;
using UTB.Casino.Domain.Entities;
using UTB.Casino.Domain.Entities.Interfaces.Repository;

namespace UTB.Casino.Application.Implementation;

public class GameSessionAppService : IGameSessionAppService
{
    private readonly IRepository<GameSession, int> _gameSessionRepository;
    private readonly IRepository<Game, int> _gameRepository;
    private readonly IAccountAppService _accountAppService; // Využijeme dříve navrženou službu pro peníze

    public GameSessionAppService(
        IRepository<GameSession, int> gameSessionRepository,
        IRepository<Game, int> gameRepository,
        IAccountAppService accountAppService)
    {
        _gameSessionRepository = gameSessionRepository;
        _gameRepository = gameRepository;
        _accountAppService = accountAppService;
    }

    public bool StartGameSession(int accountId, int gameId)
    {
        // 1. Zjistíme, jestli hra existuje (využijeme váš generický nebo specifický repository)
        var game = _gameRepository.GetById(gameId);
        if (game == null) return false;

        // 2. Zkontrolujeme a strhneme cenu hry z účtu hráče přes AccountAppService
        bool success = _accountAppService.Withdraw(accountId, game.Cost);
        if (!success)
        {
            // Hráč nemá dostatek peněz na spuštění hry
            return false; 
        }

        // 3. Vytvoříme nové herní sezení
        var session = new GameSession
        {
            StartTime = DateTime.Now,
            GameId = gameId,
            AccountId = accountId,
            Exchange = 0 // Na začátku je bilance sezení 0, než se vyhodnotí výhra
        };

        // 4. Uložíme sezení do databáze
        _gameSessionRepository.Add(session);
        return true;
    }

    public void EndGameSession(int sessionId, double finalExchange)
    {
        var session = _gameSessionRepository.GetById(sessionId);
        if (session != null)
        {
            session.EndTime = DateTime.Now;
            session.Exchange = finalExchange;
            _gameSessionRepository.Edit(session);

            // Pokud hráč vyhrál, můžeme mu peníze připsat zpět na účet
            if (finalExchange > 0)
            {
                _accountAppService.Deposit(session.AccountId, finalExchange);
            }
        }
    }
}