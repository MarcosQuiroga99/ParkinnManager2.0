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

            // Calcular plazas ocupadas y libres
            var plazasOcupadas = estacionamiento.Plaza.Count();
            var plazasLibres = estacionamiento.MaxPlaza - plazasOcupadas;

            ViewBag.PlazasOcupadas = plazasOcupadas;
            ViewBag.PlazasLibres = plazasLibres;

            return View(estacionamiento);
        }
        public IActionResult EditVehiculo(string patente)
        {
            var vehiculo = _context.vehiculos.Find(patente);
            if (vehiculo == null)
            {
                return NotFound();
            }
            return View("EditVehiculo", vehiculo); // Asegúrate de tener una vista llamada EditVehiculo
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditVehiculo(Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculo);
                    _context.SaveChanges();
                    return RedirectToAction("Details", new { id = vehiculo.EstacionamientoId });
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
            }
            return View(vehiculo);
        }

        private bool VehiculoExists(string patente)
        {
            return _context.vehiculos.Any(v => v.Patente == patente);
        }
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