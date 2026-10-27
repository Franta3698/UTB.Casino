using UTB.Casino.Domain.Entities;

namespace UTB.Casino.Application.Validators;

public class GameValidator
{
    public (bool IsValid, string ErrorMessage) ValidateBet(Account? account, Game? game, double betAmount)
    {
        if (game == null)
        {
            return (false, "Zvolená hra neexistuje.");
        }

        if (account == null)
        {
            return (false, "Uživatelský účet nebyl nalezen.");
        }

        if (betAmount <= 0)
        {
            return (false, "Sázka musí být větší než 0.");
        }

        if (account.Balance < betAmount)
        {
            return (false, "Na tuto sázku nemáte dostatek finančních prostředků.");
        }

        return (true, string.Empty);
    }
}