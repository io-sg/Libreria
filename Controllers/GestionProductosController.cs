using Microsoft.AspNetCore.Mvc;
using Libreria2.Models;
using Libreria2.Data;
using System.Linq;


namespace Libreria2.Controllers
{
    public class GestionProductosController : Controller
    {
        private readonly AppDbContext _context;

        public GestionProductosController(AppDbContext context)
        {
            _context = context;
        }

        // Acción para mostrar los productos
        public IActionResult Index()
        {
            var productos = _context.Productos.ToList();
            return View(productos);
        }

        // Acción para agregar un producto
        [HttpPost]
        public IActionResult CrearProducto(Producto producto)
        {
            if (ModelState.IsValid)
            {
                producto.fecha_registro = DateTime.Now;
                _context.Productos.Add(producto);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Acción para editar un producto
        [HttpPost]
        public IActionResult EditarProducto(Producto producto)
        {
            if (ModelState.IsValid)
            {
                var existingProducto = _context.Productos.Find(producto.id_producto);
                if (existingProducto != null)
                {
                    existingProducto.isbn = producto.isbn;
                    existingProducto.titulo = producto.titulo;
                    existingProducto.autor = producto.autor;
                    existingProducto.editorial = producto.editorial;
                    existingProducto.precio_menudeo = producto.precio_menudeo;
                    existingProducto.precio_mayoreo = producto.precio_mayoreo;
                    existingProducto.cantidad_mayoreo = producto.cantidad_mayoreo;
                    existingProducto.fecha_registro = producto.fecha_registro;

                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        // Acción para eliminar un producto
        [HttpPost]
        public IActionResult EliminarProducto(int id_producto)
        {
            var producto = _context.Productos.Find(id_producto);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
