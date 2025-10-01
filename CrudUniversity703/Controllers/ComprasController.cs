// Controllers/ComprasController.cs
using CrudUniversity703.Models;
using CRUDUniversity703.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudUniversity703.Controllers
{
    public class ComprasController : Controller
    {
        private readonly AplicationDbContext _context;

        public ComprasController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: Compras
        public IActionResult Index()
        {
            var compras = _context.Compras
                .Include(c => c.Producto)
                .ToList();

            return View(compras);
        }

        // GET: Compras/Create
        public IActionResult Create()
        {
            ViewBag.Productos = _context.Productos.ToList();
            return View();
        }

        // POST: Compras/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Compra compra)
        {
            if (ModelState.IsValid)
            {
                _context.Compras.Add(compra);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Productos = _context.Productos.ToList();
            return View(compra);
        }

        // GET: Compras/Edit/5
        public IActionResult Edit(int id)
        {
            var compra = _context.Compras.Find(id);
            if (compra == null) return NotFound();

            ViewBag.Productos = _context.Productos.ToList();
            return View(compra);
        }

        // POST: Compras/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Compra compra)
        {
            if (ModelState.IsValid)
            {
                _context.Update(compra);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Productos = _context.Productos.ToList();
            return View(compra);
        }

        // GET: Compras/Delete/5
        public IActionResult Delete(int id)
        {
            var compra = _context.Compras
                .Include(c => c.Producto)
                .FirstOrDefault(c => c.Id == id);

            if (compra == null) return NotFound();

            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var compra = _context.Compras.Find(id);
            if (compra != null)
            {
                _context.Compras.Remove(compra);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
