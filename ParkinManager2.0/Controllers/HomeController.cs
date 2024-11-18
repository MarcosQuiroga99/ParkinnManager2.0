using Microsoft.AspNetCore.Mvc;

namespace ParkinManager2._0.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Index), "Cliente");    
        }
    }
}
