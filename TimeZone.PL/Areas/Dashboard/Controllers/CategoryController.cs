using Microsoft.AspNetCore.Mvc;

namespace TimeZone.PL.Areas.Dashbord.Controllers
{
    [Area("Dashboard")]
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
