using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UTB.Casino.Application.ViewModels;
using UTB.Casino.Domain.Entities;
using UTB.Casino.Infrastructure.Database;

namespace UTB.Casino.Web.Controllers;

public class GameController : Controller
{
    private readonly CasinoDbContext _context;

    public GameController(CasinoDbContext context)
    {
        _context = context;
    }

    // GET: /Game/Index
    public async Task<IActionResult> Index()
    {
        var games = await _context.Games.ToListAsync();
        return View(games);
    }

    // GET: /Game/EditCost/5
    [HttpGet]
    public async Task<IActionResult> EditCost(int id)
    {
        var game = await _context.Games.FindAsync(id);
        if (game == null)
        {
            return NotFound();
        }


        var viewModel = new GameEditViewModel
        {
            Id = game.Id,
            Cost = game.Cost
        };

        ViewBag.GameName = game.Name;

        return View(viewModel);
    }

    // POST: /Game/EditCost/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditCost(int id, GameEditViewModel model)
    {
        if (id != model.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            // Změníme v entitě POUZE cenu
            game.Cost = model.Cost;

            // Uložíme do databáze
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Pokud validace selže, vrátíme formulář s chybami (můžeme znovu nastavit ViewBag.GameName)
        var originalGame = await _context.Games.AsNoTracking().FirstOrDefaultAsync(g => g.Id == id);
        if (originalGame != null)
        {
            ViewBag.GameName = originalGame.Name;
        }

        return View(model);
    }
}