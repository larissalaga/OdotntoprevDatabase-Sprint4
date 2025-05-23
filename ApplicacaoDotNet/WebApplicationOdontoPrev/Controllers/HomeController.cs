using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using WebApplicationOdontoPrev.Repositories.Interfaces;

namespace WebApplicationOdontoPrev.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IDentistaRepository _dentistaRepository;

        public HomeController(ILogger<HomeController> logger,
                              IPacienteRepository pacienteRepository,
                              IDentistaRepository dentistaRepository)
        {
            _logger = logger;
            _pacienteRepository = pacienteRepository;
            _dentistaRepository = dentistaRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
