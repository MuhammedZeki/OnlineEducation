using Microsoft.AspNetCore.Mvc;

namespace OnlineEdu.UI.Areas.Admin.Controllers
{


    [Area("Admin")]
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
