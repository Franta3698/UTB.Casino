using UTB.Casino.Application.Abstraction;
using UTB.Casino.Application.Validators; // Namespace našich validátorů
using UTB.Casino.Domain.Entities;
using UTB.Casino.Domain.Entities.Interfaces.Repository;

namespace UTB.Casino.Application.Implementation;

public class AccountAppService : IAccountAppService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IRepository<Transaction, int> _transactionRepository;
    private readonly AccountValidator _validator; // Přidáme validátor

    public AccountAppService(
        IAccountRepository accountRepository, 
        IRepository<Transaction, int> transactionRepository)
    {
        _accountRepository = accountRepository;
        _transactionRepository = transactionRepository;
        _validator = new AccountValidator(); // Můžete registrovat i přes DI, nebo vytvořit instanci
    }

    public bool Deposit(int accountId, double amount)
    {
        // 1. Zavoláme validaci ze samostatné složky
        var (isValid, errorMessage) = _validator.ValidateDeposit(amount);
        if (!isValid)
        {
            // Zde byste mohli chybovou hlášku zalogovat nebo vyhodit výjimku
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

        // 1. Zavoláme validaci, která zkontroluje i zůstatek na účtu
        var (isValid, errorMessage) = _validator.ValidateWithdrawal(account, amount);
        if (!isValid)
        {
            return false;
        }

        account!.Balance -= amount; // account už víme, že není null díky validátoru
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