using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
