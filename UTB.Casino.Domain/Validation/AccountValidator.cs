using UTB.Casino.Domain.Entities;

namespace UTB.Casino.Application.Validators;

public class AccountValidator
{
    // Validace pro vklad
    public (bool IsValid, string ErrorMessage) ValidateDeposit(double amount)
    {
        if (amount <= 0)
        {
            return (false, "Částka vkladu musí být větší než 0.");
        }
        if (amount > 1000000)
        {
            return (false, "Maximální jednorázový vklad je 1 000 000 Kč.");
        }
        return (true, string.Empty);
    }

    // Validace pro výběr
    public (bool IsValid, string ErrorMessage) ValidateWithdrawal(Account? account, double amount)
    {
        if (account == null)
        {
            return (false, "Účet neexistuje.");
        }
        if (amount <= 0)
        {
            return (false, "Částka výběru musí být větší než 0.");
        }
        if (account.Balance < amount)
        {
            return (false, "Nedostatek finančních prostředků na účtu.");
        }
        return (true, string.Empty);
    }
}