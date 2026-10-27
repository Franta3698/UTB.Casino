using UTB.Casino.Domain.Entities;

namespace UTB.Casino.Application.Abstraction;

public interface ICustomerAppService
{
    Customer? GetCustomerDetail(int customerId);
    void CreateCustomer(Customer customer);
}