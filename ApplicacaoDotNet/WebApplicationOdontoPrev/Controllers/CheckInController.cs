using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApplicationOdontoPrev.Models;
using WebApplicationOdontoPrev.Repositories.Interfaces;
using WebApplicationOdontoPrev.ViewModels;

namespace WebApplicationOdontoPrev.Controllers
{
    public class CheckInController : Controller
    {
        private readonly IPacienteRepository _pacienteRepository;

        public CheckInController(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task<IActionResult> Index(string id)
        {
            var paciente = await _pacienteRepository.ObterPorIdAsync(id);
            if (paciente == null) return NotFound();

            var model = new CheckInViewModel
            {
                IdPaciente = paciente.Id,
                NmPaciente = paciente.nm_paciente,
                NmPlano = paciente.PLANO.nm_plano,
                DtCheckIn = DateTime.Now,
                Contador = 1
            };

            return RedirectToAction("Pergunta", model);
        }

        public IActionResult Pergunta(CheckInViewModel model)
        {
            if (model.Contador > 10)
            {
                return RedirectToAction("Index", "PacienteHome", new { id = model.IdPaciente });
            }

            // Mock de perguntas (já que você não tem mais a tabela)
            var perguntas = new[]
            {
                "Você escovou os dentes hoje?",
                "Usou fio dental nas últimas 24h?",
                "Sente dor ao mastigar?",
                "Notou sangramento recente na gengiva?",
                "Está em tratamento odontológico atualmente?",
                "Você fuma?",
                "Tem sensibilidade a alimentos gelados?",
                "Já fez limpeza nos últimos 6 meses?",
                "Sente gosto metálico na boca com frequência?",
                "Já fez tratamento de canal?"
            };

            if (model.Contador > perguntas.Length)
            {
                return RedirectToAction("Index", "PacienteHome", new { id = model.IdPaciente });
            }

            model.DsPergunta = perguntas[model.Contador - 1];
            model.DsResposta = string.Empty;

            return View("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> Avancar(CheckInViewModel model)
        {
            var paciente = await _pacienteRepository.ObterPorIdAsync(model.IdPaciente);
            if (paciente == null) return NotFound();

            // Grava nova resposta no CHECK_IN do paciente
            paciente.CHECK_IN.Add(new CheckIn
            {
                data = model.DtCheckIn,
                pergunta = model.DsPergunta,
                resposta = model.DsResposta
            });

            await _pacienteRepository.AtualizarAsync(paciente.Id, paciente);

            model.Contador += 1;

            return RedirectToAction("Pergunta", model);
        }
    }
}
