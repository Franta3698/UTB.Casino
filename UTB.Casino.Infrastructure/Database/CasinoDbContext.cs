using Microsoft.EntityFrameworkCore;
using UTB.Casino.Domain.Entities;
using UTB.Casino.Infrastructure.Database.Seeding;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using UTB.Casino.Infrastructure.Identity;

namespace UTB.Casino.Infrastructure.Database;

public class CasinoDbContext : IdentityDbContext <User, Role, int>
{
    public DbSet<Game> Games { get; set; }
    public DbSet<GameSession> GameSessions { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Bonus> Bonuses { get; set; }
    
   
    public CasinoDbContext(DbContextOptions<CasinoDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        

        GameInit gameInit = new GameInit();

        modelBuilder.Entity<Game>().HasData(gameInit.GetGames2());
        UserInit userInit = new UserInit();
        modelBuilder.Entity<User>().HasData(
            userInit.GetAdmin(),
            userInit.GetPlayer());
        
        AccountInit accountInit = new AccountInit();
        modelBuilder.Entity<Account>().HasData(
            accountInit.GetAdminAccount(),
            accountInit.GetPlayerAccount()
        );
        BonusInit bonusInit = new BonusInit();

        modelBuilder.Entity<Bonus>().HasData(
            bonusInit.GetWelcomeBonus(),
            bonusInit.GetPlayerBonus()
        );
        GameSessionInit gameSessionInit = new GameSessionInit();

        modelBuilder.Entity<GameSession>().HasData(
            gameSessionInit.GetAdminSession(),
            gameSessionInit.GetPlayerSession()
        );
    }
}

