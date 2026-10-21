using Microsoft.EntityFrameworkCore;
using UTB.Casino.Domain.Entities;
using UTB.Casino.Infrastructure.Database.Seeding;


namespace UTB.Casino.Infrastructure.Database;

public class CasinoDbContext : DbContext
{
    public DbSet<Game> Games { get; set; }
    public DbSet<GameSession>  GameSessions { get; set; }
    public DbSet<Customer>  Customers { get; set; }
    
    public CasinoDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        CustomerInit customerInit = new CustomerInit();
        GameInit gameInit = new GameInit();
        
        modelBuilder.Entity<Customer>().HasData(customerInit.GetCustomers2());
        modelBuilder.Entity<Game>().HasData(gameInit.GetGames2());
    }
}

