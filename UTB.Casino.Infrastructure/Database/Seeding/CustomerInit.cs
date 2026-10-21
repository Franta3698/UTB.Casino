using UTB.Casino.Domain.Entities;
namespace UTB.Casino.Infrastructure.Database.Seeding;

internal class CustomerInit
{
    public IList<Domain.Entities.Customer> GetCustomers2()
    {
        IList<Domain.Entities.Customer> customers = new List<Domain.Entities.Customer>();

        customers.Add(new Domain.Entities.Customer
        {
            Id = 1,
            UserName = "bigdickRandy67",
            BankAccountId = 1,
            Email = "sugoma@seznam.cz",
            FirstName = "Sugoma",
            LastName = "Nuts",
            PhoneNumber = "+35988888888"
        });
        customers.Add(new Domain.Entities.Customer
        {
            Id = 2,
            UserName = "ballz",
            BankAccountId = 4,
            Email = "number12COCK@seznam.cz",
            FirstName = "BUSSSS",
            LastName = "Raketak",
            PhoneNumber = "+9807969795"
        });
        
        return customers;

    }
}