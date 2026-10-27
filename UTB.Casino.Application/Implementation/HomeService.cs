using UTB.Casino.Application.Abstraction;
using UTB.Casino.Application.ViewModels;

namespace UTB.Casino.Application.Implementation;

public class HomeService : IHomeService
{
    private readonly IGameAppService _gameAppService;

    public HomeService(IGameAppService gameAppService)
    {
        _gameAppService = gameAppService;
    }

    public IndexViewModel GetIndexViewModel()
    {
        IndexViewModel viewModel = new IndexViewModel();
        // Na hlavní stránce zobrazíme seznam našich 3 her
        viewModel.Games = _gameAppService.SelectAll(); 
        return viewModel;
    }
}