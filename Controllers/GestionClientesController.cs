using Libreria2.Data;
using Libreria2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Libreria2.Controllers
{
    public class GestionClientesController : Controller
    {
        private readonly AppDbContext _context;

        public GestionClientesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var clientes = _context.Clientes.ToList();
            return View(clientes);
        }

        [HttpPost]
        public IActionResult AgregarCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.direccion = "N/A"; // Asignar valor por defecto
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditarCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteExistente = _context.Clientes.Find(cliente.id_cliente);
                if (clienteExistente != null)
                {
                    clienteExistente.nombre = cliente.nombre;
                    clienteExistente.correo = cliente.correo;
                    clienteExistente.telefono = cliente.telefono;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EliminarCliente(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
