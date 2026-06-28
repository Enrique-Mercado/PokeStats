using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PokeStatsV1.Models;

namespace PokeStatsV1.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.Nombre = "Empolloupullus Marximus Phersiphus Isping";

        return View();
    }

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
