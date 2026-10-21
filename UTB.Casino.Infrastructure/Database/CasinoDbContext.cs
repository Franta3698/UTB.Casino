using Microsoft.EntityFrameworkCore;
using UTB.Casino.Domain.Entities;
using UTB.Casino.Domain.Entities.Interfaces;


namespace UTB.Casino.Infrastructure.Database;

public class CasinoDbContext : DbContext
{
    public DbSet<Game> Games { get; set; }
    public DbSet<GameSession>  GameSessions { get; set; }
    public DbSet<Customer>  Customers { get; set; }
    
    public CasinoDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
    }
}

