using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationOdontoPrev.Repositories.Interfaces;
using WebApplicationOdontoPrev.ViewModels;

namespace WebApplicationOdontoPrev.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IAuditoriaRepository _auditoriaRepository;

        public ReportsController(
            IPacienteRepository pacienteRepository,
            IAuditoriaRepository auditoriaRepository)
        {
            _pacienteRepository = pacienteRepository;
            _auditoriaRepository = auditoriaRepository;
        }

        public async Task<IActionResult> PerguntaReport(string cpf)
        {
            var relatorio = new List<PerguntaReportViewModel>();
            var cpfs = new List<string>();
            var pacientes = await _pacienteRepository.ObterTodosAsync();

            foreach (var paciente in pacientes)
            {
                cpfs.Add(paciente.nr_cpf);

                if (string.IsNullOrEmpty(cpf) || paciente.nr_cpf == cpf)
                {
                    var respostas = paciente.CHECK_IN?.Select(ci => new PerguntaReportViewModel
                    {
                        NmPaciente = paciente.nm_paciente,
                        NrCpf = paciente.nr_cpf,
                        DtCheckIn = ci.data,
                        DsPergunta = ci.pergunta,
                        DsResposta = ci.resposta,
                        IdPaciente = paciente.Id.ToString()
                    }).ToList() ?? new List<PerguntaReportViewModel>();

                    relatorio.AddRange(respostas);
                }
            }

            ViewBag.CPFs = cpfs.Distinct().ToList();
            return View(relatorio);
        }

        public async Task<IActionResult> RaioXReport(string cpf)
        {
            var relatorio = new List<RaioXAnalisesReportViewModel.RaioXAnalise>();
            var cpfs = new List<string>();
            var pacientes = await _pacienteRepository.ObterTodosAsync();

            foreach (var paciente in pacientes)
            {
                cpfs.Add(paciente.nr_cpf);

                if (string.IsNullOrEmpty(cpf) || paciente.nr_cpf == cpf)
                {
                    var analises = paciente.RAIO_X?
                        .Where(rx => rx.analise != null)
                        .Select(rx => new RaioXAnalisesReportViewModel.RaioXAnalise
                        {
                            nm_paciente = paciente.nm_paciente,
                            nr_cpf = paciente.nr_cpf,
                            dt_data_raio_x = rx.dt_data_raio_x,
                            ds_raio_x = rx.ds_raio_x,
                            dt_analise_raio_x = rx.analise?.dt_analise_raio_x ?? DateTime.MinValue,
                            ds_analise_raio_x = rx.analise?.ds_analise_raio_x ?? string.Empty,
                            nm_plano = paciente.PLANO?.nm_plano ?? string.Empty,
                            nr_total_raio_x_analisados = paciente.RAIO_X.Count(rx => rx.analise != null),
                            ds_descricao_analise = rx.analise?.ds_analise_raio_x ?? string.Empty
                        }).ToList() ?? new List<RaioXAnalisesReportViewModel.RaioXAnalise>();

                    relatorio.AddRange(analises);
                }
            }

            var viewModel = new RaioXAnalisesReportViewModel
            {
                raio_x_analises = relatorio,
                nr_cpfs = cpfs.Distinct().ToList()
            };

            return View(viewModel);
        }

        public async Task<IActionResult> AuditoriaReport(string tabela = "", string operacao = "",
                                                         string usuario = "", DateTime? dataInicio = null,
                                                         DateTime? dataFim = null)
        {
            var auditorias = await _auditoriaRepository.GetAll();

            if (!string.IsNullOrEmpty(tabela))
                auditorias = auditorias.Where(a => a.NmTabela == tabela).ToList();

            if (!string.IsNullOrEmpty(operacao))
                auditorias = auditorias.Where(a => a.DsOperacao == operacao).ToList();

            if (!string.IsNullOrEmpty(usuario))
                auditorias = auditorias.Where(a => a.IdUsuario == usuario).ToList();

            if (dataInicio.HasValue && dataFim.HasValue)
                auditorias = auditorias.Where(a => a.DtOperacao >= dataInicio && a.DtOperacao <= dataFim).ToList();

            var todasAuditorias = await _auditoriaRepository.GetAll();
            var tabelas = todasAuditorias.Select(a => a.NmTabela ?? string.Empty).Distinct().ToList();
            var operacoes = todasAuditorias.Select(a => a.DsOperacao ?? string.Empty).Distinct().ToList();
            var usuarios = todasAuditorias.Select(a => a.IdUsuario ?? string.Empty).Distinct().ToList();

            var auditoriaItems = auditorias.Select(a => new AuditoriaReportViewModel.AuditoriaItem
            {
                IdAuditoria = a.IdAuditoria.ToString(),
                NmTabela = a.NmTabela ?? string.Empty,
                DsOperacao = a.DsOperacao ?? string.Empty,
                DtOperacao = a.DtOperacao,
                IdUsuario = a.IdUsuario ?? string.Empty,
                NmValoresAnteriores = a.NmValoresAnteriores ?? string.Empty
            }).ToList();

            var viewModel = new AuditoriaReportViewModel
            {
                Auditorias = auditoriaItems,
                Tabelas = tabelas,
                Operacoes = operacoes,
                Usuarios = usuarios,
                DataInicio = dataInicio,
                DataFim = dataFim
            };

            return View(viewModel);
        }
    }
}
