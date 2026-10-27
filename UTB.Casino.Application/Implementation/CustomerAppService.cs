using UTB.Casino.Application.Abstraction;
using UTB.Casino.Domain.Entities;
using UTB.Casino.Domain.Entities.Interfaces.Repository;

namespace UTB.Casino.Application.Implementation;

public class CustomerAppService : ICustomerAppService
{
    private readonly IRepository<Customer, int> _customerRepository;
    private readonly IRepository<Account, int> _accountRepository;

    public CustomerAppService(
        IRepository<Customer, int> customerRepository,
        IRepository<Account, int> accountRepository)
    {
        _customerRepository = customerRepository;
        _accountRepository = accountRepository;
    }

    public Customer? GetCustomerDetail(int customerId)
    {
        return _customerRepository.GetById(customerId);
    }

    public void CreateCustomer(Customer customer)
    {
        // Příklad logiky: při vytvoření zákazníka mu můžeme rovnou založit i účet, pokud ho nemá
        if (customer.Account == null)
        {
            var newAccount = new Account
            {
                Balance = 0,
                Currency = "CZK"
            };
            _accountRepository.Add(newAccount);
            customer.AccountId = newAccount.Id;
        }

        _customerRepository.Add(customer);
    }
}