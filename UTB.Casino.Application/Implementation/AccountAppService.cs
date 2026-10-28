using UTB.Casino.Application.Abstraction;
using UTB.Casino.Application.Validators; // Namespace našich validátorů
using UTB.Casino.Domain.Entities;
using UTB.Casino.Domain.Entities.Interfaces.Repository;

namespace UTB.Casino.Application.Implementation;

public class AccountAppService : IAccountAppService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IRepository<Transaction, int> _transactionRepository;
    private readonly AccountValidator _validator;

    public AccountAppService(
        IAccountRepository accountRepository, 
        IRepository<Transaction, int> transactionRepository)
    {
        _accountRepository = accountRepository;
        _transactionRepository = transactionRepository;
        _validator = new AccountValidator();
    }

    public bool Deposit(int accountId, double amount)
    {

        var (isValid, errorMessage) = _validator.ValidateDeposit(amount);
        if (!isValid)
        {

            return false; 
        }

        var account = _accountRepository.GetById(accountId);
        if (account == null) return false;

        account.Balance += amount;
        _accountRepository.Edit(account);

        var transaction = new Transaction
        {
            AccountId = accountId,
            Amount = amount,
            Date = DateTime.Now,
            Type = "Deposit"
        };
        _transactionRepository.Add(transaction);

        return true;
    }

    public bool Withdraw(int accountId, double amount)
    {
        var account = _accountRepository.GetById(accountId);

        var (isValid, errorMessage) = _validator.ValidateWithdrawal(account, amount);
        if (!isValid)
        {
            return false;
        }

        account!.Balance -= amount;
        _accountRepository.Edit(account);

        var transaction = new Transaction
        {
            AccountId = accountId,
            Amount = -amount,
            Date = DateTime.Now,
            Type = "Withdraw"
        };
        _transactionRepository.Add(transaction);

        return true;
    }

    public double GetBalance(int accountId)
    {
        var account = _accountRepository.GetById(accountId);
        return account?.Balance ?? 0;
    }
}