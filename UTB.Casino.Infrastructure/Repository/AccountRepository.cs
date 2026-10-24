using UTB.Casino.Domain.Entities;
using UTB.Casino.Domain.Entities.Interfaces.Repository;
using UTB.Casino.Infrastructure.Database;

namespace UTB.Casino.Infrastructure.Repository;

public class AccountRepository : Repository<Account, int>, IAccountRepository
{
    public AccountRepository(CasinoDbContext context) : base(context)
    {
        
    }
}