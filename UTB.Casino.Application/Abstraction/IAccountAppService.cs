using UTB.Casino.Domain.Entities;

namespace UTB.Casino.Application.Abstraction;

public interface IAccountAppService
{
    double GetBalance(int accountId);
    bool Deposit(int accountId, double amount);
    bool Withdraw(int accountId, double amount);
}