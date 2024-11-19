using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Estacionamiento.Models;
using System.Linq;

namespace ParkinManager2._0.Controllers
{
    public class VehiculoController : Controller
    {
        private readonly EstacionamientoContext _context;

        public VehiculoController(EstacionamientoContext context)
        {
            _context = context;
        }

        // GET: Vehiculo
        public IActionResult Index()
        {
            var vehiculos = _context.vehiculos.Include(v => v.Dueño).ToList();
            return View(vehiculos);
        }

        // GET: Vehiculo/Details/ABC123
        public IActionResult Details(string id)
        {
            var vehiculo = _context.vehiculos
                .Include(v => v.Dueño) // Incluir el dueño del vehículo
                .FirstOrDefault(v => v.Patente == id);

            if (vehiculo == null)
            {
                return NotFound();
            }
            return View(vehiculo);
        }

        // GET: Vehiculo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehiculo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.vehiculos.Add(vehiculo);
                _context.SaveChanges();
                return RedirectToAction("Details", "Estacionamiento", new { id = vehiculo.EstacionamientoId });
            }
            return View(vehiculo);
        }
        // GET: Vehiculo/Edit/ABC123
        public IActionResult Edit(string id)
        {
            var vehiculo = _context.vehiculos.Find(id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            return View(vehiculo);
        }

        // POST: Vehiculo/Edit/ABC123
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, Vehiculo vehiculo)
        {
            if (id != vehiculo.Patente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculo);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculoExists(vehiculo.Patente))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw; // Vuelve a lanzar la excepción si hay un error diferente
                    }
                }
                return RedirectToAction("Details", "Estacionamiento", new { id = vehiculo.EstacionamientoId });
            }
            return View(vehiculo);
        }

        // Método auxiliar para verificar si el vehículo existe
        private bool VehiculoExists(string patente)
        {
            return _context.vehiculos.Any(v => v.Patente == patente);
        }

        // GET: Vehiculo/Delete/ABC123
        public IActionResult Delete(string id)
        {
            var vehiculo = _context.vehiculos.Find(id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            return View(vehiculo);
        }

        // POST: Vehiculo/Delete/ABC123
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var vehiculo = _context.vehiculos.Find(id);
            if (vehiculo != null)
            {
                _context.vehiculos.Remove(vehiculo);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}