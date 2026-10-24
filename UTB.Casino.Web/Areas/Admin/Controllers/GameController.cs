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

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [ValidateAntiForgeryToken]
    [HttpPost]
    public IActionResult Create(Game game)
    {
        if (ModelState.IsValid)
        {
            _gameAppService.Create(game);
            return RedirectToAction(nameof(GameController.Select));
        }
        
        return View(game);
    }
    
    [ValidateAntiForgeryToken]
    [HttpPost]
    public IActionResult Delete(int id)
    {
        bool deleted = _gameAppService.Delete(id);

        if (deleted)
        {
            return RedirectToAction(nameof(GameController.Select));
        }
        else
            return NotFound();
    }
}