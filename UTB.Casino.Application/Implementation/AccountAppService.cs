using UTB.Casino.Application.Abstraction;
using UTB.Casino.Domain.Entities;
using UTB.Casino.Domain.Entities.Interfaces.Repository;

namespace UTB.Casino.Application.Implemetation;

public class AccountAppService : IAccountAppService
{
    IAccountRepository _accountRepository;
    
    public AccountAppService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public IList<Account> SelectAll()
    {
        return _accountRepository.GetAll().ToList();
    }
}