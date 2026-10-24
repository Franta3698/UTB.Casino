using UTB.Casino.Domain.Entities;
namespace UTB.Casino.Application.Abstraction;

public interface IGameAppService
{
    IList<Game> SelectAll();
}