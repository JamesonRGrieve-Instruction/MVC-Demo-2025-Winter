using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjectName.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectName.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    // List of Mad Lib templates
    private readonly List<string> _madLibTemplates = new List<string>
    {
        "One day, {0} decided to visit {1}. They packed their favorite snack, {2}, and put on their comfiest {3}. Hopping into their {5} {4}, they drove off. Upon arrival, everyone in {1} was eating {2} and wearing {3}. \"What a strange place!\" thought {0}, as they drove their {5} {4} back home.",
        "{0} went for a walk in {1} wearing bright {5} {3}. Suddenly, they craved {2} and decided to drive their {4} to the nearest store. They bought a huge amount of {2} and shared it with everyone they met.",
        "In the quirky town of {1}, {0} was famous for their unusual {5} {3}. One afternoon, while enjoying some {2}, {0} saw a {4} zoom past. \"I need one of those!\" {0} exclaimed, finishing their {2}."
    };

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
        // Input validation
        if (string.IsNullOrWhiteSpace(userName) ||
            string.IsNullOrWhiteSpace(townName) ||
            string.IsNullOrWhiteSpace(foodType) ||
            string.IsNullOrWhiteSpace(footwearType) ||
            string.IsNullOrWhiteSpace(vehicleType) ||
            string.IsNullOrWhiteSpace(colorName))
        {
            TempData["ErrorMessage"] = "Please fill out all fields.";
            return RedirectToAction("Input");
        }

        // Select a random template
        var random = new Random();
        int index = random.Next(_madLibTemplates.Count);
        string selectedTemplate = _madLibTemplates[index];

        ViewBag.SelectedTemplate = selectedTemplate; // Pass the template string via ViewBag
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
