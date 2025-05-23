using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationOdontoPrev.Models;
using WebApplicationOdontoPrev.Repositories.Interfaces;
using WebApplicationOdontoPrev.ViewModels;

namespace WebApplicationOdontoPrev.Controllers
{
    public class GerenciarDentistasController : Controller
    {
        private readonly IDentistaRepository _dentista;

        public GerenciarDentistasController(IDentistaRepository dentista)
        {
            _dentista = dentista;
        }

        private async Task<GerenciarDentistasViewModel> CarregarDentistas(string orderBy = "nm_dentista", string sortOrder = "asc")
        {
            var dentistas = await _dentista.ObterTodosAsync();

            dentistas = (orderBy, sortOrder) switch
            {
                ("nm_dentista", "asc") => dentistas.OrderBy(d => d.nm_dentista).ToList(),
                ("nm_dentista", "desc") => dentistas.OrderByDescending(d => d.nm_dentista).ToList(),
                ("ds_cro", "asc") => dentistas.OrderBy(d => d.ds_cro).ToList(),
                ("ds_cro", "desc") => dentistas.OrderByDescending(d => d.ds_cro).ToList(),
                _ => dentistas.ToList()
            };

            return new GerenciarDentistasViewModel { Dentistas = dentistas };
        }

        public async Task<IActionResult> OrdenarDentistas(string campo)
        {
            var currentSortOrder = TempData["CurrentSortOrder"] as string ?? "asc";
            var currentSortField = TempData["CurrentSortField"] as string ?? "nm_dentista";
            string newSortOrder = (currentSortField == campo && currentSortOrder == "asc") ? "desc" : "asc";

            TempData["CurrentSortField"] = campo;
            TempData["CurrentSortOrder"] = newSortOrder;

            var viewModel = await CarregarDentistas(campo, newSortOrder);
            return View("Index", viewModel);
        }

        public async Task<IActionResult> EditarDentista(string id)
        {
            var dentista = await _dentista.ObterPorIdAsync(id);
            if (dentista == null) return NotFound();

            return View("DetalhesDentistas", dentista);
        }

        [HttpPost]
        public async Task<IActionResult> SalvarDentista(Dentista dentista)
        {
            if (string.IsNullOrEmpty(dentista.Id))
                await _dentista.InserirAsync(dentista);
            else
                await _dentista.AtualizarAsync(dentista.Id, dentista);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ExcluirDentista(string id)
        {
            await _dentista.RemoverAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult AdicionarDentista()
        {
            return View("DetalhesDentistas", new Dentista());
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await CarregarDentistas();
            return View(viewModel);
        }

        [HttpGet("GerenciarDentistas/Perfil/{id}")]
        public async Task<IActionResult> Perfil(string id)
        {
            var dentista = await _dentista.ObterPorIdAsync(id);
            if (dentista == null) return NotFound();

            return View("Perfil", dentista);
        }

        [HttpPost]
        public async Task<IActionResult> SalvarPerfilDentista(Dentista model)
        {
            if (!ModelState.IsValid)
                return View("Perfil", model);

            var dentista = await _dentista.ObterPorIdAsync(model.Id);
            if (dentista == null) return NotFound();

            dentista.nm_dentista = model.nm_dentista;
            dentista.ds_cro = model.ds_cro;
            dentista.ds_email = model.ds_email;
            dentista.nr_telefone = model.nr_telefone;
            dentista.ds_doc_identificacao = model.ds_doc_identificacao;

            await _dentista.AtualizarAsync(dentista.Id, dentista);
            return RedirectToAction("Perfil", new { id = dentista.Id });
        }
    }
}
