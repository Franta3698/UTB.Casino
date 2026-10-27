using UTB.Casino.Application.ViewModels;

namespace UTB.Casino.Application.Abstraction;

public interface IGameAppService
{
    IEnumerable<GameViewModel> SelectAll();
    GameViewModel? GetById(int id);
}