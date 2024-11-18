using Estacionamiento.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace ParkinManager2._0.Controllers
{
    public class ClienteController : Controller
    {
 
        public IActionResult Index()
        {
            
            
            return View();
        }
    }
    public class Compuesto()
    {
    EstacionamientoContext context = new EstacionamientoContext();
   private ArrayList Listados()
    {
            List<Cliente> listadoClientes = context.cliente.ToList();
            List<Estacionamiento> listadoEstacionamiento = context.estacionamientos.ToList();

    }
    }
 
}
