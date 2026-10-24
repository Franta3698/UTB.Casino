using UTB.Casino.Domain.Entities;
namespace UTB.Casino.Application.Abstraction;

public interface IAccountAppService
{
    IList<Account> SelectAll();
}