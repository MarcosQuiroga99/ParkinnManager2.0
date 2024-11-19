using Microsoft.AspNetCore.Mvc;
using Estacionamiento.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ParkinManager2._0.Controllers
{
    public class VehiculoController : Controller
    {
        private readonly EstacionamientoContext _context;

        public VehiculoController(EstacionamientoContext context)
        {
            _context = context;
        }

        // Otros métodos...

        // GET: Vehiculo/Details/ABC123
        public IActionResult Details(string id)
        {
            var vehiculo = _context.vehiculos
                .Include(v => v.Dueño) // Incluir el dueño del vehículo si es necesario
                .FirstOrDefault(v => v.Patente == id);

            if (vehiculo == null)
            {
                return NotFound();
            }
            return View(vehiculo);
        }
    }
}
