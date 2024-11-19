using Microsoft.AspNetCore.Mvc;
using Estacionamiento.Models;
using System.Linq;

namespace ParkinManager2._0.Controllers
{
    public class ClienteController : Controller
    {
        private readonly EstacionamientoContext _context;

        public ClienteController(EstacionamientoContext context)
        {
            _context = context;
        }

        // GET: Cliente
        public IActionResult Index()
        {
            var clientes = _context.cliente.ToList(); // Obtener todos los clientes
            return View(clientes);
        }

        // GET: Cliente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.cliente.Add(cliente);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public IActionResult Edit(int id)
        {
            var cliente = _context.cliente.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Cliente cliente)
        {
            if (id != cliente.Dni)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.cliente.Update(cliente);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }
    }
}