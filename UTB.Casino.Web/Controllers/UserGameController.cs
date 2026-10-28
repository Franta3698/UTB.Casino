
using Microsoft.AspNetCore.Mvc;
using UTB.Casino.Application.Abstraction;
using UTB.Casino.Application.ViewModels;

namespace UTB.Casino.Web.Controllers;

public class UserGameController : Controller
{
    private readonly IGameAppService _gameAppService;

    public UserGameController(IGameAppService gameAppService)
    {
        _gameAppService = gameAppService;
    }


    [HttpGet]
    public IActionResult EditCost(int id)
    {
        var game = _gameAppService.GetById(id);

        if (game is null)
        {
            return NotFound();
        }

        var model = new GameEditViewModel
        {
            Id = game.Id,
            Cost = game.Cost
        };

        return View(model);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EditCost(GameEditViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var game = _gameAppService.GetById(model.Id);

        if (game is null)
        {
            return NotFound();
        }

        game.Cost = model.Cost;

        _gameAppService.Edit(game);

        return RedirectToAction("Index", "Game");
    }
}
