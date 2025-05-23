namespace WebApplicationOdontoPrev.ViewModels
{
    public class CheckInViewModel
    {
        public string IdPaciente { get; set; } = string.Empty; // Corrigido de int para string
        public string NmPaciente { get; set; } = string.Empty;
        public string NmPlano { get; set; } = string.Empty;

        public int IdCheckIn { get; set; }
        public DateTime DtCheckIn { get; set; }

        public int IdExtratoPontos { get; set; }
        public int NrNumeroPontos { get; set; }
        public string DsMovimentacao { get; set; } = string.Empty;
        public DateTime DtExtrato { get; set; }

        public int IdPergunta { get; set; }
        public string DsPergunta { get; set; } = string.Empty;

        public int IdResposta { get; set; }
        public string DsResposta { get; set; } = string.Empty;

        public int Contador { get; set; }
    }
}
