using Microsoft.AspNetCore.Mvc;

namespace WebAutopark.Controllers
{
    public class VehicleTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
