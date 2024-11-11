
namespace LibraVerse.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using LibraVerse.Web.ViewModels;
    public class HomeController : Controller
    {


        public HomeController()
        {

        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Home Page";
            ViewData["Message"] = "Welcome to the LibraVerse Web App!";
            return View();
        }
    }
}
