using Microsoft.AspNetCore.Mvc;
namespace UTB.Casino.Web.Controllers.Areas.Admin.Controllers;
[Area("Admin")]
public class GameController : Controller
{
    public IActionResult Select()
    {
        return View();
    }
}