using UTB.Casino.Application.Abstraction;
using UTB.Casino.Application.ViewModels;

namespace UTB.Eshop.Application.Implementation
{
    public class HomeService : IHomeService
    {
        IGameAppService _gameAppService;
        IAccountAppService _accountAppService;

        public HomeService(IGameAppService gameAppService,
            IAccountAppService accountAppService)
        {
            _gameAppService = gameAppService;
            _accountAppService = accountAppService;
        }

        public IndexViewModel GetIndexViewModel()
        {
            IndexViewModel viewModel = new IndexViewModel();
            viewModel.Games = _gameAppService.SelectAll();
            viewModel.Accounts = _accountAppService.SelectAll();
            return viewModel;
        }
    }
}