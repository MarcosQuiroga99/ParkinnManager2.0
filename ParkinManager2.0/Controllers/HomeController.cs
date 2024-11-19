using Microsoft.AspNetCore.Mvc;
using Estacionamiento.Models;
using System.Linq;

namespace ParkinManager2._0.Controllers
{
    public class HomeController : Controller
    {
        private readonly EstacionamientoContext _context;

        public HomeController(EstacionamientoContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchTerm)
        {
            // Realiza la búsqueda si hay un término de búsqueda
            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Intenta buscar un cliente por DNI
                var cliente = _context.cliente.FirstOrDefault(c => c.Dni.ToString() == searchTerm);
                if (cliente != null)
                {
                    return RedirectToAction("Details", "Cliente", new { id = cliente.Dni });
                }

                // Intenta buscar un vehículo por patente
                var vehiculo = _context.vehiculos.FirstOrDefault(v => v.Patente == searchTerm);
                if (vehiculo != null)
                {
                    return RedirectToAction("Details", "Vehiculo", new { id = vehiculo.Patente });
                }

                // Si no se encuentra el cliente o vehículo, puedes mostrar un mensaje
                ViewBag.Message = "No se encontró ningún cliente o vehículo con ese término de búsqueda.";
            }

            return View();
        }
    }
}