using Microsoft.AspNetCore.Mvc;
namespace UTB.Casino.Web.Controllers;

[Area("Security")]
public class AccountController : Controller
{
    public IActionResult Register()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }
}