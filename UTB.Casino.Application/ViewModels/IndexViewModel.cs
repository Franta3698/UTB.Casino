using UTB.Casino.Domain.Entities;
namespace UTB.Casino.Application.ViewModels;

public class IndexViewModel
{
    public IList<Account> Accounts { get; set; }
    public IList<Game> Games { get; set; }
}