using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjectName.Models;

namespace ProjectName.Controllers;

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

    public IActionResult Input()
    {
        return View();
    }

    public IActionResult Example()
    {
        return View();
    }

    public IActionResult OutputExample()
    {
        return View();
    }

    [HttpPost]
    public IActionResult MadLibOutput(string userName, string townName, string foodType, string footwearType, string vehicleType, string colorName)
    {
        ViewData["UserName"] = userName;
        ViewData["TownName"] = townName;
        ViewData["FoodType"] = foodType;
        ViewData["FootwearType"] = footwearType;
        ViewData["VehicleType"] = vehicleType;
        ViewData["ColorName"] = colorName;
        return View("Output"); // Specify the Output view
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
