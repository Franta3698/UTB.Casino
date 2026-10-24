using UTB.Casino.Domain.Entities;
using UTB.Casino.Domain.Entities.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using UTB.Casino.Domain.Entities;
using UTB.Casino.Domain.Entities.Interfaces.Repository;
using UTB.Casino.Infrastructure.Database;
namespace UTB.Casino.Infrastructure.Repository;

public class GameRepository : Repository<Game, int>, IGameRepository
{
    public GameRepository(CasinoDbContext context) : base(context)
    {
        
    }
}