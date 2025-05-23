using System;
using System.Collections.Generic;

namespace WebApplicationOdontoPrev.ViewModels
{
    public class ExtratoPontosViewModel
    {
        public string IdPaciente { get; set; } = string.Empty;
        public string NmPaciente { get; set; } = string.Empty;
        public string NmPlano { get; set; } = string.Empty;
        public int TotalPontos { get; set; }
        public List<ExtratoPontosItemViewModel> ExtratoPontos { get; set; } = new List<ExtratoPontosItemViewModel>();
    }

    public class ExtratoPontosItemViewModel
    {
        public DateTime DtExtrato { get; set; }
        public int NrNumeroPontos { get; set; }
        public string DsMovimentacao { get; set; } = string.Empty;
    }
}
