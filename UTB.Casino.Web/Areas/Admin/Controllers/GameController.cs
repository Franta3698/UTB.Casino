using Microsoft.AspNetCore.Mvc;
using UTB.Casino.Application.Abstraction;
using UTB.Casino.Domain.Entities;
namespace UTB.Casino.Web.Areas.Admin.Controllers;
[Area("Admin")]
public class GameController : Controller
{
    IGameAppService _gameAppService;
    
    public  GameController(IGameAppService gameAppService)
    {
        _gameAppService = gameAppService;
    }
    
    public IActionResult Select()
    {
        IList<Game> games = _gameAppService.SelectAll();
        return View(games);
    }
}