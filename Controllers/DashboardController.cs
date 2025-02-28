using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Libreria2.Controllers
{
    public class DashboardController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
