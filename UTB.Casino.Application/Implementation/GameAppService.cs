using UTB.Casino.Application.Abstraction;
using UTB.Casino.Domain.Entities;
using UTB.Casino.Domain.Entities.Interfaces.Repository;

namespace UTB.Casino.Application.Implementation;

public class GameAppService : IGameAppService
{
    private readonly IGameRepository _gameRepository;

    public GameAppService(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public IList<Game> SelectAll()
    {
        return _gameRepository.GetAll().ToList();
    }

    public Game? GetById(int id)
    {
        return _gameRepository.GetById(id);
    }

    public void Create(Game game)
    {
        _gameRepository.Add(game);
    }

    public bool Delete(int id)
    {
        var game = _gameRepository.GetById(id);

        if (game is not null)
        {
            _gameRepository.Delete(game);
            return true;
        }
        return false;
    }
    public void Edit(Game game)
    {
        _gameRepository.Edit(game);
    }
}