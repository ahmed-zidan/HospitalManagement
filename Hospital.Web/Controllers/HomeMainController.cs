using Hospital.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hospital.Web.Controllers
{
    public class HomeMainController : Controller
    {
        private readonly ILogger<HomeMainController> _logger;

        public HomeMainController(ILogger<HomeMainController> logger)
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
}
