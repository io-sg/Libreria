using Microsoft.AspNetCore.Mvc;
using Libreria2.Data;
using Microsoft.EntityFrameworkCore;
using Libreria2.Models;

namespace Libreria2.Controllers
{
    public class PromocionesController : Controller
    {
        private readonly AppDbContext _context;

        public PromocionesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Promociones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Promociones.Include(p => p.IdProductoNavigation).ToListAsync());
        }

        // GET: Promociones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Promociones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProducto,Descuento,FechaInicio,FechaFin")] Promocione promocion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promocion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(promocion);
        }

        // DELETE: Promociones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promocion = await _context.Promociones.FindAsync(id);
            _context.Promociones.Remove(promocion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}