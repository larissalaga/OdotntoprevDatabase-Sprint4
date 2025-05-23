using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplicationOdontoPrev.Repositories.Interfaces;
using WebApplicationOdontoPrev.ViewModels;

namespace WebApplicationOdontoPrev.Controllers
{
    public class LoginController : Controller
    {
        private readonly IPacienteRepository _pacienteRepository;

        public LoginController(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ObterPaciente(LoginViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.NrCpf))
            {
                ModelState.AddModelError("NrCpf", "Insira um CPF válido");
                return View("Index", model);
            }

            var paciente = await _pacienteRepository.ObterPorCpfAsync(model.NrCpf);

            if (paciente == null)
            {
                ModelState.AddModelError("NrCpf", "Paciente não encontrado");
                return View("Index", model);
            }

            model.IdPaciente = paciente.Id;

            return View("Index", model);
        }
    }
}
