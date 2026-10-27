namespace UTB.Casino.Application.Validators;

public class CustomerValidator
{
    public (bool IsValid, string ErrorMessage) ValidateAge(DateTime birthDate)
    {
        var today = DateTime.Today;
        var age = today.Year - birthDate.Year;
        
        // Zohlednění, zda už měl letos narozeniny
        if (birthDate.Date > today.AddYears(-age)) 
        {
            age--;
        }

        if (age < 18)
        {
            return (false, "Hráč musí být starší 18 let pro vstup do kasina.");
        }

        if (age > 120)
        {
            return (false, "Zadaný věk není platný.");
        }

        return (true, string.Empty);
    }
}