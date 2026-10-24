using UTB.Casino.Application.ViewModels;
namespace UTB.Casino.Application.Abstraction;

public interface IHomeService
{
    IndexViewModel GetIndexViewModel();
}