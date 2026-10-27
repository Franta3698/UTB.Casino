namespace UTB.Casino.Application.Abstraction;

public interface IGameSessionAppService
{
    // Spuštění nové hry pro konkrétní účet a vybranou hru
    bool StartGameSession(int accountId, int gameId);
    
    // Ukončení sezení (např. uložení výsledku / výhry)
    void EndGameSession(int sessionId, double finalExchange);
}