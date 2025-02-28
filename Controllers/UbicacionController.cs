using Microsoft.AspNetCore.Mvc;
using Libreria2.Models;
using Libreria2.Data;
using System.Linq;
using AspNetCoreGeneratedDocument;

namespace Libreria2.Controllers
{
    public class UbicacionController : Controller
    {
        private readonly AppDbContext _context;

        // Constructor para inyectar el contexto de la base de datos
        public UbicacionController(AppDbContext context)
        {
            _context = context;
        }

        // Acción para mostrar todas las ubicaciones
        public IActionResult Index()
        {
            var ubicaciones = _context.Ubicaciones.ToList();
            return View(ubicaciones); 
        }

        // Acción para crear una nueva Ubicación
        [HttpPost]
        public IActionResult CrearUbicacion(Ubicacion ubicacion)
        {
           

            if (ModelState.IsValid)  // Validar si el modelo es válido
            {
                ubicacion.fecha = DateTime.Now;

                _context.Ubicaciones.Add(ubicacion);
                _context.SaveChanges();  // Se guarda en la base de datos

                int idGenerado = ubicacion.idUbicacion;  // El idUbicacion se genera automáticamente

                ubicacion.descripcion = "M" + idGenerado;

                // Actualizamos el código en la base de datos
                _context.SaveChanges();
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

        // Acción para editar una ubicación
        [HttpPost]
        public IActionResult EditarUbicacion(Ubicacion ubicacion)
        {
            if (ModelState.IsValid)  // Validar si el modelo es válido
            {
                var existingUbicacion = _context.Ubicaciones.Find(ubicacion.idUbicacion);
                if (existingUbicacion != null)
                {
                    existingUbicacion.descripcion = ubicacion.descripcion;
                    existingUbicacion.observaciones = ubicacion.observaciones;
                    existingUbicacion.estatus = ubicacion.estatus;
                    existingUbicacion.fecha = ubicacion.fecha;
                    existingUbicacion.idUsuario = ubicacion.idUsuario;
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


            return RedirectToAction("Index");  // Redirigir a la vista
        }

        // Acción para eliminar una ubicación (cambiar el status a 2)
        [HttpPost]
        public IActionResult EliminarUbicacion(int idUbicacion)
        {
            var ubicacion = _context.Ubicaciones.FirstOrDefault(a => a.idUbicacion == idUbicacion);  // Buscar el almacén por ID
            if (ubicacion != null)
            {
                ubicacion.estatus = 2;  // Cambiar el estado a deshabilitado (status = 2)
                _context.Ubicaciones.Update(ubicacion);  // Actualizar la ubicación
                _context.SaveChanges();  // Guardar los cambios
            }
            return RedirectToAction("Index"); 
        }

        // Acción para rehabilitar una Ubicación (cambiar el status a 1)
        [HttpPost]
        public IActionResult RehabilitarUbicacion(int idUbicacion)
        {
            var ubicacion = _context.Ubicaciones.FirstOrDefault(a => a.idUbicacion == idUbicacion);  // Buscar el almacén por ID
            if (ubicacion != null)
            {
                ubicacion.estatus = 1;  // Cambiar el estado a habilitado (status = 1)
                _context.Ubicaciones.Update(ubicacion);  // Actualizar la ubicación
                _context.SaveChanges();  // Guardar los cambios
            }
            return RedirectToAction("Index");
        }
    }
}
