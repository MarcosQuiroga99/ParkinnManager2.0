using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Estacionamiento.Models;
using System.Linq;

namespace ParkinManager2._0.Controllers
{
    public class EstacionamientoController : Controller
    {
        private readonly EstacionamientoContext _context;

        public EstacionamientoController(EstacionamientoContext context)
        {
            _context = context;
        }

        // GET: Estacionamiento
        public IActionResult Index()
        {
            var estacionamientos = _context.estacionamientos
                .Include(e => e.Plaza) // Incluir vehículos
                .Include(e => e.Administrador) // Incluir administrador si es necesario
                .ToList();
            return View(estacionamientos);
        }

        // GET: Estacionamiento/Details/5
        public IActionResult Details(int id)
        {
            var estacionamiento = _context.estacionamientos
                .Include(e => e.Plaza)
                .Include(e => e.Administrador)
                .FirstOrDefault(e => e.Id == id);

            if (estacionamiento == null)
            {
                return NotFound();
            }

            return View(estacionamiento);
        }

        // GET: Estacionamiento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estacionamiento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EstacionamientoContext estacionamiento)
        {
          
            if (ModelState.IsValid)
            {
                _context.estacionamientos.Add(estacionamiento);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(estacionamiento);
        }

        // GET: Estacionamiento/Edit/5
        public IActionResult Edit(int id)
        {
            var estacionamiento = _context.estacionamientos.Find(id);
            if (estacionamiento == null)
            {
                return NotFound();
            }
            return View(estacionamiento);
        }

        // POST: Estacionamiento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Estacionamiento estacionamiento)
        {
            if (id != estacionamiento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.estacionamientos.Update(estacionamiento);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstacionamientoExists(estacionamiento.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(estacionamiento);
        }

        // GET: Estacionamiento/Delete/5
        public IActionResult Delete(int id)
        {
            var estacionamiento = _context.estacionamientos.Find(id);
            if (estacionamiento == null)
            {
                return NotFound();
            }
            return View(estacionamiento);
        }

        // POST: Estacionamiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var estacionamiento = _context.estacionamientos.Find(id);
            if (estacionamiento != null)
            {
                _context.estacionamientos.Remove(estacionamiento);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool EstacionamientoExists(int id)
        {
            return _context.estacionamientos.Any(e => e.Id == id);
        }
    }
}