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

        public IActionResult Details(int id)
        {
            var estacionamiento = _context.estacionamientos
                .Include(e => e.Plaza) // Incluir vehículos
                .FirstOrDefault(e => e.Id == id);

            if (estacionamiento == null)
            {
                return NotFound();
            }

            return View(estacionamiento);
        }

        // Acción para crear un vehículo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.vehiculos.Add(vehiculo);
                _context.SaveChanges();
                return RedirectToAction("Details", new { id = vehiculo.EstacionamientoId });
            }
            return View(vehiculo); // Si hay errores, volver a mostrar el formulario
        }
    }
}