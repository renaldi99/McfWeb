using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MfcWeb.Models;

namespace MfcWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var username = HttpContext.Session.GetString("username");
        bool isUserLoggedIn = username != null;
        ViewBag.IsUserLoggedIn = isUserLoggedIn;

        if (!isUserLoggedIn)
        {
            return RedirectToAction("Login", "Login");
        }

        return View();
    }

    public IActionResult Privacy()
    {
        var username = HttpContext.Session.GetString("username");
        ViewData["username"] = username;

        if (username == null)
        {
            return RedirectToAction("Login", "Login");
        }

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

