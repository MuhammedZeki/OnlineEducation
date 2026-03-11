using Microsoft.AspNetCore.Mvc;
using OnlineEdu.UI.Models;
using System.Diagnostics;

namespace OnlineEdu.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
