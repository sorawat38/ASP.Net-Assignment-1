using Microsoft.AspNetCore.Mvc;

namespace InlandMarinaMVC.Controllers;
// *********************************************************************
// * ContactController.cs
// *
// * Project: Assignment 1                             
// * Description: ASP.NET MVC Web Application for Inland Marina      
// * Version: 1.0.0                                        
// * Date: 2024-11-26                                      
// * Author: Sorawat (James) Tanthikun                     
// * Purpose: Contact page controller for Inland Marina MVC web application
//*********************************************************************
public class ContactController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}