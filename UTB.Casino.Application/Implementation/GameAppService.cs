using UTB.Casino.Application.Abstraction;
using UTB.Casino.Domain.Entities;
using UTB.Casino.Domain.Entities.Interfaces.Repository;
namespace UTB.Casino.Application.Implemetation;

public class GameAppService : IGameAppService
{
    IGameRepository _gameRepository;
    
    public GameAppService(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public IList<Game> SelectAll()
    {
        return _gameRepository.GetAll().ToList();
    }
}