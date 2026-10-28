using UTB.Casino.Application.Abstraction;
using UTB.Casino.Domain.Entities;
using UTB.Casino.Domain.Entities.Interfaces.Repository;

namespace UTB.Casino.Application.Implementation;

public class GameSessionAppService : IGameSessionAppService
{
    private readonly IRepository<GameSession, int> _gameSessionRepository;
    private readonly IRepository<Game, int> _gameRepository;
    private readonly IAccountAppService _accountAppService;

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
        var game = _gameRepository.GetById(gameId);
        if (game == null) return false;
        
        bool success = _accountAppService.Withdraw(accountId, game.Cost);
        if (!success)
        {

            return false; 
        }


        var session = new GameSession
        {
            StartTime = DateTime.Now,
            GameId = gameId,
            AccountId = accountId,
            Exchange = 0
        };

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


            if (finalExchange > 0)
            {
                _accountAppService.Deposit(session.AccountId, finalExchange);
            }
        }
    }
}