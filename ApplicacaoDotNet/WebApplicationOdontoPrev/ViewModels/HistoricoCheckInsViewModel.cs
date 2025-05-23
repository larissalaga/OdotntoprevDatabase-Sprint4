using System;
using System.Collections.Generic;

namespace WebApplicationOdontoPrev.ViewModels
{
    public class HistoricoCheckInsViewModel
    {
        public string IdPaciente { get; set; } = string.Empty;
        public string NmPaciente { get; set; } = string.Empty;
        public string NmPlano { get; set; } = string.Empty;
        public int TotalPontos { get; set; }
        public List<HistoricoCheckInsItemViewModel> PerguntasRespostas { get; set; } = new List<HistoricoCheckInsItemViewModel>();
    }

    public class HistoricoCheckInsItemViewModel
    {
        public DateTime DtCheckIn { get; set; }
        public string DsPergunta { get; set; } = string.Empty;
        public string DsResposta { get; set; } = string.Empty;
    }
}
