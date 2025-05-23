using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationOdontoPrev.Models;
using WebApplicationOdontoPrev.Repositories.Interfaces;
using WebApplicationOdontoPrev.ViewModels;
using static WebApplicationOdontoPrev.ViewModels.GerenciarPacientesViewModel;

namespace WebApplicationOdontoPrev.Controllers
{
    public class GerenciarPacientesController : Controller
    {
        private readonly IPacienteRepository _paciente;
        private readonly IDentistaRepository _dentista;

        public GerenciarPacientesController(IPacienteRepository paciente, IDentistaRepository dentista)
        {
            _paciente = paciente;
            _dentista = dentista;
        }

        private async Task<GerenciarPacientesViewModel> CarregarPacientes(string orderBy = "Nome", string sortOrder = "asc")
        {
            var pacientes = await _paciente.ObterTodosAsync();
            var viewModel = new GerenciarPacientesViewModel();

            foreach (var paciente in pacientes)
            {
                viewModel.Pacientes.Add(new PacienteDados
                {
                    Paciente = paciente,
                    Plano = paciente.PLANO,
                    Dentistas = paciente.DENTISTA.Select(d => new Dentista
                    {
                        nm_dentista = d.nm_dentista,
                        ds_cro = d.ds_cro
                    }).ToList()
                });
            }

            TempData["CurrentSortField"] = orderBy;
            TempData["CurrentSortOrder"] = sortOrder;
            TempData.Keep("CurrentSortField");
            TempData.Keep("CurrentSortOrder");

            viewModel.Pacientes = (orderBy, sortOrder) switch
            {
                ("Nome", "asc") => viewModel.Pacientes.OrderBy(p => p.Paciente.nm_paciente).ToList(),
                ("Nome", "desc") => viewModel.Pacientes.OrderByDescending(p => p.Paciente.nm_paciente).ToList(),
                ("Cpf", "asc") => viewModel.Pacientes.OrderBy(p => p.Paciente.nr_cpf).ToList(),
                ("Cpf", "desc") => viewModel.Pacientes.OrderByDescending(p => p.Paciente.nr_cpf).ToList(),
                ("Plano", "asc") => viewModel.Pacientes.OrderBy(p => p.Plano.nm_plano).ToList(),
                ("Plano", "desc") => viewModel.Pacientes.OrderByDescending(p => p.Plano.nm_plano).ToList(),
                ("Nascimento", "asc") => viewModel.Pacientes.OrderBy(p => p.Paciente.dt_nascimento).ToList(),
                ("Nascimento", "desc") => viewModel.Pacientes.OrderByDescending(p => p.Paciente.dt_nascimento).ToList(),
                _ => viewModel.Pacientes
            };

            return viewModel;
        }

        public async Task<IActionResult> OrdenarPacientes(string campo)
        {
            var currentSortOrder = TempData["CurrentSortOrder"] as string ?? "asc";
            var currentSortField = TempData["CurrentSortField"] as string ?? "Nome";
            string newSortOrder = (currentSortField == campo && currentSortOrder == "asc") ? "desc" : "asc";

            var viewModel = await CarregarPacientes(campo, newSortOrder);
            return View("Index", viewModel);
        }

        public async Task<IActionResult> EditarPaciente(string id)
        {
            var paciente = await _paciente.ObterPorIdAsync(id);
            if (paciente == null) return NotFound();

            var viewModel = new PacienteDados
            {
                Paciente = paciente,
                Plano = paciente.PLANO,
                Dentistas = paciente.DENTISTA.Select(d => new Dentista
                {
                    nm_dentista = d.nm_dentista,
                    ds_cro = d.ds_cro
                }).ToList()
            };

            return View("DetalhesPaciente", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SalvarPacienteDados(Paciente paciente)
        {
            if (string.IsNullOrEmpty(paciente.Id))
                await _paciente.InserirAsync(paciente);
            else
                await _paciente.AtualizarAsync(paciente.Id, paciente);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> SalvarPerfil(PerfilViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Perfil", model);
            }

            var paciente = await _paciente.ObterPorIdAsync(model.IdPaciente);
            if (paciente == null) return NotFound();

            paciente.nm_paciente = model.NmPaciente;
            paciente.dt_nascimento = model.DtNascimento;
            paciente.ds_sexo = model.DsSexo;
            paciente.nr_telefone = model.NrTelefone;
            paciente.ds_email = model.DsEmail;

            await _paciente.AtualizarAsync(paciente.Id, paciente);

            return RedirectToAction("Perfil", new { id = paciente.Id });
        }

        public async Task<IActionResult> ExcluirPaciente(string id)
        {
            await _paciente.RemoverAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult AdicionarPaciente()
        {
            var pacienteDados = new PacienteDados();
            return View("DetalhesPaciente", pacienteDados);
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await CarregarPacientes();
            return View(viewModel);
        }

        [HttpGet("GerenciarPacientes/Perfil/{id}")]
        public async Task<IActionResult> Perfil(string id)
        {
            var paciente = await _paciente.ObterPorIdAsync(id);
            if (paciente == null) return NotFound();

            var viewModel = new PerfilViewModel
            {
                IdPaciente = paciente.Id.ToString(),
                NmPaciente = paciente.nm_paciente,
                NrCpf = paciente.nr_cpf,
                DtNascimento = paciente.dt_nascimento,
                DsSexo = paciente.ds_sexo,
                NrTelefone = paciente.nr_telefone,
                DsEmail = paciente.ds_email,
                NmPlano = paciente.PLANO?.nm_plano ?? "Sem Plano"
            };

            return View(viewModel);
        }
    }
}
