using Microsoft.AspNetCore.Mvc;
using Estacionamiento.Models; // Asegúrate de que este espacio de nombres sea correcto
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

        // Acción para mostrar la vista de inicio
        public IActionResult Index(string searchTerm)
        {
            // Inicializa una lista de estacionamientos
            var estacionamientos = _context.estacionamientos.ToList();

            // Si hay un término de búsqueda, intenta buscar un cliente o vehículo
            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Busca un cliente por DNI
                var cliente = _context.cliente.FirstOrDefault(c => c.Dni.ToString() == searchTerm);
                if (cliente != null)
                {
                    // Redirige a la vista de detalles del cliente
                    return RedirectToAction("Details", "Cliente", new { id = cliente.Dni, searchTerm });
                }

                // Busca un vehículo por patente
                var vehiculo = _context.vehiculos.FirstOrDefault(v => v.Patente == searchTerm);
                if (vehiculo != null)
                {
                    // Redirige a la vista de detalles del vehículo
                    return RedirectToAction("Details", "Vehiculo", new { id = vehiculo.Patente, searchTerm });
                }

                // Si no se encuentra el cliente o vehículo, puedes mostrar un mensaje
                ViewBag.Message = "No se encontró ningún cliente o vehículo con ese término de búsqueda.";
            }

            // Devuelve la vista de inicio con la lista de estacionamientos
            return View(estacionamientos);
        }
        public IActionResult GoToEstacionamiento(int id)
        {
            // Redirige a la acción Details del EstacionamientoController
            return RedirectToAction("Details", "Estacionamiento", new { id });
        }
    }
}