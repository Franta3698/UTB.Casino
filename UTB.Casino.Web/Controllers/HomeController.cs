using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UTB.Casino.Web.Models;
using UTB.Casino.Application.Abstraction;
using UTB.Casino.Application.ViewModels;


namespace UTB.Casino.Web.Controllers;

public class HomeController : Controller
{
    

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}