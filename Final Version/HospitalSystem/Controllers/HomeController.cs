using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HospitalSystem.Models;

namespace HospitalSystem.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult CaseNumbers()
    {
        return View();
    }

    public IActionResult Doctors()
    {
        return View();
    }

    public IActionResult Polyclinics()
    {
        return View();
    }

    public IActionResult NewsDetail(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return RedirectToAction("Index");
        }

        ViewData["NewsId"] = id;
        return View("NewsDetail");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
