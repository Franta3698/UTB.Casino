namespace UTB.Casino.Application.Abstraction;

public interface IGameSessionAppService
{
    
    bool StartGameSession(int accountId, int gameId);

    
    void EndGameSession(int sessionId, double finalExchange);
}