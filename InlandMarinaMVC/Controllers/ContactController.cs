using Microsoft.AspNetCore.Mvc;

namespace InlandMarinaMVC.Controllers;

public class ContactController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}