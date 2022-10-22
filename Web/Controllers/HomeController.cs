using System.Diagnostics;
using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IVolunteerService _categoryService;

    public HomeController(ILogger<HomeController> logger, IVolunteerService categoryService)
    {
        _logger = logger;
        _categoryService = categoryService;
    }

    public async Task<IActionResult> Index()
    {
        var home = new HomeInfoDto();
        ViewBag.Volunteers = await _categoryService.GetVolunteers() ;

        return View(home);
    }

    public async Task<IActionResult> About()
    {
        ViewBag.Volunteers = await _categoryService.GetVolunteers() ;

        return View();
    }

    public async Task<IActionResult> Privacy()
    {
        ViewBag.Volunteers = await _categoryService.GetVolunteers() ;

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
