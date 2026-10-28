using UTB.Casino.Domain.Entities;

namespace UTB.Casino.Application.Abstraction;

public interface IGameAppService
{
    IList<Game> SelectAll();
    Game? GetById(int id);
    void Create(Game game);
    bool Delete(int id);
}