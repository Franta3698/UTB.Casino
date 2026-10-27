using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using UTB.Casino.Domain.Entities.Interfaces.Repository;
using UTB.Casino.Infrastructure.Database;
using UTB.Casino.Infrastructure.Repository;
using UTB.Casino.Infrastructure.Identity;
using UTB.Casino.Application.Abstraction;
using UTB.Casino.Application.Implementation;
using UTB.Casino.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 1. PostgreSQL Database Context
builder.Services.AddDbContext<CasinoDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. ASP.NET Core Identity Configuration
builder.Services.AddIdentity<User, Role>(options =>
{
    // Zde můžete nastavit např. pravidla pro hesla (pro školní projekty se často mírně volní)
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 3;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
.AddEntityFrameworkStores<CasinoDbContext>()
.AddDefaultTokenProviders();

// 3. Repositories (všechny entity)
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IRepository<Customer, int>, CustomerRepository>();
builder.Services.AddScoped<IRepository<GameSession, int>, Repository<GameSession, int>>();
builder.Services.AddScoped<IRepository<Transaction, int>, Repository<Transaction, int>>();
builder.Services.AddScoped<IRepository<Bonus, int>, Repository<Bonus, int>>();

// 4. Application Services
builder.Services.AddScoped<IGameAppService, GameAppService>();
builder.Services.AddScoped<IAccountAppService, AccountAppService>();
builder.Services.AddScoped<ICustomerAppService, CustomerAppService>();
builder.Services.AddScoped<IGameSessionAppService, GameSessionAppService>();
builder.Services.AddScoped<IHomeService, HomeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

// 5. Authentication & Authorization (musí být v tomto pořadí před UseAuthorization!)
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Game}/{action=Select}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();