using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebAutopark.Models;

namespace WebAutopark.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}