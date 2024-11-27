using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using InlandMarinaMVC.Models;

namespace InlandMarinaMVC.Controllers;
// *********************************************************************
// * HomeController.cs
// *
// * Project: Assignment 1                             
// * Description: ASP.NET MVC Web Application for Inland Marina      
// * Version: 1.0.0                                        
// * Date: 2024-11-26                                      
// * Author: Sorawat (James) Tanthikun                     
// * Purpose: Home page controller for Inland Marina MVC web application
//*********************************************************************
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}