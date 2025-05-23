using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationOdontoPrev.Repositories.Interfaces;
using WebApplicationOdontoPrev.ViewModels;
using static WebApplicationOdontoPrev.ViewModels.HistoricoCheckInsViewModel;

namespace WebApplicationOdontoPrev.Controllers
{
    public class HistoricoCheckInsController : Controller
    {
        private readonly IPacienteRepository _pacienteRepository;

        public HistoricoCheckInsController(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task<IActionResult> Index(string id)
        {
            var paciente = await _pacienteRepository.ObterPorIdAsync(id);
            if (paciente == null)
                return NotFound();

            var historicoCheckInItems = paciente.CHECK_IN.Select(c => new HistoricoCheckInsItemViewModel
            {
                DtCheckIn = c.data,
                DsPergunta = c.pergunta,
                DsResposta = c.resposta
            }).ToList();

            var viewModel = new HistoricoCheckInsViewModel
            {
                IdPaciente = paciente.Id,
                NmPaciente = paciente.nm_paciente,
                NmPlano = paciente.PLANO.nm_plano,
                PerguntasRespostas = historicoCheckInItems
            };

            return View(viewModel);
        }
    }
}
