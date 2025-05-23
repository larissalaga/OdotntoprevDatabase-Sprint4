using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationOdontoPrev.Repositories.Interfaces;
using WebApplicationOdontoPrev.ViewModels;
using static WebApplicationOdontoPrev.ViewModels.ExtratoPontosViewModel;

namespace WebApplicationOdontoPrev.Controllers
{
    public class ExtratoPontosController : Controller
    {
        private readonly IPacienteRepository _pacienteRepository;

        public ExtratoPontosController(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task<IActionResult> Index(string id)
        {
            var paciente = await _pacienteRepository.ObterPorIdAsync(id);
            if (paciente == null)
                return NotFound();

            int totalPontos = paciente.EXTRATO_PONTOS.Sum(x => x.nr_numero_pontos);

            var viewModel = new ExtratoPontosViewModel
            {
                IdPaciente = paciente.Id,
                NmPaciente = paciente.nm_paciente,
                NmPlano = paciente.PLANO.nm_plano,
                TotalPontos = totalPontos,
                ExtratoPontos = paciente.EXTRATO_PONTOS.Select(x => new ExtratoPontosItemViewModel
                {
                    DtExtrato = x.dt_extrato,
                    NrNumeroPontos = x.nr_numero_pontos,
                    DsMovimentacao = x.ds_movimentacao
                }).ToList()
            };

            return View(viewModel);
        }
    }
}
