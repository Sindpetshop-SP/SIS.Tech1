using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SIS.Tech.Models;

namespace SIS.Tech.Controllers.System;

public class HomeController : BaseController
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        if (!VerificaSession())
        {
            return RedirectToAction("Login", "Auth");
        }

        return View();
    }

    public IActionResult Privacy()
    {


        if (!VerificaSession())
        {
            return RedirectToAction("Login", "Auth");
        }

        return View();
    }

    public IActionResult FAQ()
    {


        if (!VerificaSession())
        {
            return RedirectToAction("Login", "Auth");
        }

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
