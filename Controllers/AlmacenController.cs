using Microsoft.AspNetCore.Mvc;
using Libreria2.Models;
using Libreria2.Data;
using System.Linq;
using AspNetCoreGeneratedDocument;

namespace Libreria2.Controllers
{
    public class AlmacenController : Controller
    {
        private readonly AppDbContext _context;

        // Constructor para inyectar el contexto de la base de datos
        public AlmacenController(AppDbContext context)
        {
            _context = context;
        }

        // Acción para mostrar todos los almacenes
        public IActionResult Index()
        {
            var almacenes = _context.Almacen.ToList();  // Obtener todos los almacenes de la base de datos
            return View(almacenes);  // Pasar los almacenes a la vista
        }

        // Acción para crear un nuevo almacén
        [HttpPost]
        public IActionResult CrearAlmacen(Almacen almacen)
        {
            // Verificar si ya existe un almacén con el mismo nombre
            var almacenExistente = _context.Almacen.FirstOrDefault(a => a.nombre.Trim().ToLower() == almacen.nombre.Trim().ToLower());

            if (almacenExistente != null)
            {
                // Si ya existe, agregar un error de validación
                // Guardar mensaje de error en TempData
                TempData["ErrorAgregarAlmacen"] = "Ya existe un almacén con el nombre: "+@almacen.nombre;
                return RedirectToAction("Index");  // Redirigir a la lista de almacenes

            }

            if (ModelState.IsValid)  // Validar si el modelo es válido
            {
                almacen.nombre = almacen.nombre.Trim().ToLower();
                almacen.fecha = DateTime.Now;
                _context.Almacen.Add(almacen);  // Agregar el almacén a la base de datos
                _context.SaveChanges();  // Guardar los cambios
                return RedirectToAction("Index");  // Redirigir a la lista de almacenes
            }
            else
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine($"Error: {error.ErrorMessage}");
                    }
                }
            }

            return RedirectToAction("Index");  // Redirigir a la lista de almacenes

        }

        // Acción para editar un almacén
        [HttpPost]
        public IActionResult EditarAlmacen(Almacen almacen)
        {

            // Verificar si ya existe un almacén con el mismo nombre (excluyendo el actual)
            var almacenDuplicado = _context.Almacen
                .FirstOrDefault(a => a.nombre.Trim().ToLower() == almacen.nombre.Trim().ToLower() && a.idAlmacen != almacen.idAlmacen);

            if (almacenDuplicado != null)
            {
                TempData["ErrorEditarAlmacen"] = "Ya existe un almacén con el nombre: "+ @almacen.nombre;
                TempData["EditIdAlmacen"] = almacen.idAlmacen;  // Guardar el ID del almacén editado
                return RedirectToAction("Index");  // Redirigir a la lista de almacenes
            }

            if (ModelState.IsValid)  // Validar si el modelo es válido
            {
                almacen.nombre = almacen.nombre.Trim().ToLower();
                var existingAlmacen = _context.Almacen.Find(almacen.idAlmacen);
                if (existingAlmacen != null)
                {
                    existingAlmacen.nombre = almacen.nombre;
                    existingAlmacen.observaciones = almacen.observaciones;
                    existingAlmacen.status = almacen.status;
                    existingAlmacen.fecha = almacen.fecha;
                    existingAlmacen.idUsuario = almacen.idUsuario;
                    _context.SaveChanges();
                }
            }
            else
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine($"Error: {error.ErrorMessage}");
                    }
                }
            }


            return RedirectToAction("Index");  // Redirigir a la lista de almacenes
        }

        // Acción para eliminar un almacén (cambiar el status a 2)
        [HttpPost]
        public IActionResult EliminarAlmacen(int idAlmacen)
        {
            var almacen = _context.Almacen.FirstOrDefault(a => a.idAlmacen == idAlmacen);  // Buscar el almacén por ID
            if (almacen != null)
            {
                almacen.status = 2;  // Cambiar el estado a deshabilitado (status = 2)
                _context.Almacen.Update(almacen);  // Actualizar el almacén
                _context.SaveChanges();  // Guardar los cambios
            }
            return RedirectToAction("Index");  // Redirigir a la lista de almacenes
        }

        // Acción para rehabilitar un almacén (cambiar el status a 1)
        [HttpPost]
        public IActionResult RehabilitarAlmacen(int idAlmacen)
        {
            var almacen = _context.Almacen.FirstOrDefault(a => a.idAlmacen == idAlmacen);  // Buscar el almacén por ID
            if (almacen != null)
            {
                almacen.status = 1;  // Cambiar el estado a habilitado (status = 1)
                _context.Almacen.Update(almacen);  // Actualizar el almacén
                _context.SaveChanges();  // Guardar los cambios
            }
            return RedirectToAction("Index");  // Redirigir a la lista de almacenes
        }
    }
}
