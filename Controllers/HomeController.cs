using Libreria2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Libreria2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
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

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult GestionClientes()
        {
            return View();
        }

        public IActionResult GestionCompras()
        {
            return View();
        }

        public IActionResult GestionEmpleados()
        {
            return View();
        }

        public IActionResult GestionInventario()
        {
            return View();
        }

        public IActionResult GestionProductos()
        {
            return View();
        }

        public IActionResult GestionPromociones()
        {
            return View();
        }

        public IActionResult GestionProvedores()
        {
            return View();
        }

        public IActionResult PuntoVenta()
        {
            return View();
        }

        public IActionResult ReporteEstadisticas()
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
