using UTB.Casino.Application.Abstraction;
using UTB.Casino.Application.ViewModels;
using UTB.Casino.Domain.Entities.Interfaces.Repository;

namespace UTB.Casino.Application.Implementation;

public class GameAppService : IGameAppService
{
    private readonly IGameRepository _gameRepository;

    public GameAppService(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public IEnumerable<GameViewModel> SelectAll()
    {
        var games = _gameRepository.GetAll();

        return games.Select(g => new GameViewModel
        {
            Id = g.Id,
            Name = g.Name,
            Description = g.Description,
            Cost = g.Cost,           // Opraveno z MinBet na Cost
            Picture = g.Picture,     // Přidáno
            AltPicture = g.AltPicture // Přidáno
        }).ToList();
    }

    public GameViewModel? GetById(int id)
    {
        var game = _gameRepository.GetById(id);
        if (game == null) return null;

        return new GameViewModel
        {
            Id = game.Id,
            Name = game.Name,
            Description = game.Description,
            Cost = game.Cost,
            Picture = game.Picture,
            AltPicture = game.AltPicture
        };
    }
}