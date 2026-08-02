using System.Diagnostics;
using GymSystem__1.Models;
using Microsoft.AspNetCore.Mvc;

namespace GymSystem__1.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}