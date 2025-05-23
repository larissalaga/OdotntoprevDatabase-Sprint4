using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationOdontoPrev.Repositories.Interfaces;
using WebApplicationOdontoPrev.ViewModels;

namespace WebApplicationOdontoPrev.Controllers
{
    public class PacienteHomeController : Controller
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteHomeController(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task<IActionResult> Index(string id)
        {
            var paciente = await _pacienteRepository.ObterPorIdAsync(id);
            if (paciente == null) return NotFound();

            var totalPontos = paciente.EXTRATO_PONTOS.Sum(e => e.nr_numero_pontos);

            var viewModel = new PacienteHomeViewModel
            {
                id = paciente.Id,
                nm_paciente = paciente.nm_paciente,
                nr_cpf = paciente.nr_cpf,
                nm_plano = paciente.PLANO.nm_plano,
                total_pontos = totalPontos
            };

            return View(viewModel);
        }
    }
}
