using Microsoft.AspNetCore.Mvc;

namespace InlandMarinaMVC.Controllers;

public class SlipsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}