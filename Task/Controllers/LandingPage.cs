using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Task.Models;

namespace Task.Controllers
{
    public class LandingPageController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string FirstName, string LastName)
        {
            ViewData["Message"] = $"Hello, {FirstName} {LastName}!";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
