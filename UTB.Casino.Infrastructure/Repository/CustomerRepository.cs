using UTB.Casino.Domain.Entities;
using UTB.Casino.Domain.Entities.Interfaces.Repository;
using UTB.Casino.Infrastructure.Database;

namespace UTB.Casino.Infrastructure.Repository;

public class CustomerRepository : Repository<Customer, int>, ICustomerRepository
{
    private readonly CasinoDbContext _context;

    public CustomerRepository(CasinoDbContext context) : base(context)
    {
        _context = context;
    }

    // Zde můžete v budoucnu dopisovat vlastní specifické dotazy,
    // např. hledání zákazníka podle e-mailu nebo Identity User ID.
}