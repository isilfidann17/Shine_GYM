using Microsoft.AspNetCore.Mvc;
using SporSalonu_Odev.Models;
using SporSalonu_Odev.Data;
using System.Diagnostics;
using System.Linq;

namespace SporSalonu_Odev.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly SporContext _context;

        public HomeController(ILogger<HomeController> logger, SporContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Hakkimizda()
        {
            return View();
        }

        public IActionResult Antrenorler()
        {
            var egitmenListesi = _context.Egitmenler.ToList();
            return View(egitmenListesi);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}